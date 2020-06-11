using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace Kitchen
{
    public partial class Form2 : Form
    {
        public BFCamera cam0;
        private Size frameSize;

        Image<Gray, byte> blue;
        Image<Gray, byte> green;
        Image<Gray, byte> red;
        Image<Gray, byte>[] grays;
        Image<Bgr, byte> bgr;
        Image<Bgr, byte> background;
        bool backgroundSet = false;

        string objName;
        bool addObject = false;

        int imgFrameNum;
        Mat imgMat;
        Mat[] imgSplitMat;

        Image<Gray, byte> img1;
        Image<Bgr, byte> img2;
        Mat element;
        Point p;

        List<ContourData> contourDataList;
        List<ContourData> objectList;
        double[,] featureArray;

        const int nFeatures = 7;

        bool showLabels = false;
        bool showDistanceMetric = false;

        public struct ContourData
        {
            public ContourData(int _key, double _area, Rectangle _rect, RotatedRect _minRect, RotatedRect _ellipseRect, Moments _moments, double _arcLength)
            {
                key = _key;
                area = _area;
                rect = _rect;
                minRect = _minRect;
                ellipseRect = _ellipseRect;
                moments = _moments;
                arcLength = _arcLength;
                name = "";

                // calculate centroid from raw moments
                centroid = new Point((int)(moments.M10 / moments.M00), (int)(moments.M01 / moments.M00));

                // calculate eigenvalues from central moments to get eccentricity
                double mup20 = moments.Mu20 / moments.M00;
                double mup02 = moments.Mu02 / moments.M00;
                double mup11 = moments.Mu11 / moments.M00;
                double term1 = ((mup20 + mup02) / 2);
                double term2 = (Math.Sqrt((4.0 * mup11 * mup11) + Math.Pow(mup20 - mup02, 2.0)) / 2);
                double[] eigenvalues = new double[] { term1 + term2, term1 - term2 };
                eccentricity = Math.Sqrt(1.0 - (eigenvalues[1] / eigenvalues[0]));

                angle = ellipseRect.Angle;

                minRectAspect = minRect.Size.Width / minRect.Size.Height;
                if (minRectAspect < 1.0)
                {
                    minRectAspect = 1.0 / minRectAspect;
                }

                double[] _huMoments = CvInvoke.HuMoments(_moments);
                double[] _logHuMoments = new double[_huMoments.Length];
                for (int i = 0; i < _logHuMoments.Length; i++)
                {
                    if (_huMoments[i] > 0)
                    {
                        _logHuMoments[i] = Math.Log10(Math.Abs(_huMoments[i]));
                    }
                    else
                    {
                        _logHuMoments[i] = -1.0 * Math.Log10(Math.Abs(_huMoments[i]));
                    }
                }
                logHuMoments = _logHuMoments;

            }
            public int key { get; }
            public double area { get; }
            public Rectangle rect { get; }
            public RotatedRect minRect { get;  }
            public RotatedRect ellipseRect { get; }
            public Moments moments { get; }

            public double arcLength { get; }
            
            public double[] logHuMoments { get; }
            public Point centroid { get; }
            public double angle { get; }
            public double eccentricity { get; }
            public double minRectAspect { get; }
            public string name { get; set; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void openCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cam0 = new BFCamera(this);
            cam0.OpenCamera();
            frameSize = cam0.frameSize;
            aTimer.Enabled = true;

            blue = new Image<Gray, byte>(frameSize);
            green = new Image<Gray, byte>(frameSize);
            red = new Image<Gray, byte>(frameSize);
            grays = new Image<Gray, byte>[] { blue, green, red };
            img1 = new Image<Gray, byte>(frameSize);
            img2 = new Image<Bgr, byte>(frameSize);

            element = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            p = new Point(-1, -1);
            contourDataList = new List<ContourData>();
            objectList = new List<ContourData>();
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {
            bgr = frameToBGR();
            imageBox1.Image = bgr;
            img2.SetZero();

            if (backgroundSet)
            {
                // threshold, erode, dilate

                CvInvoke.AbsDiff(green, background[1], img1);
                CvInvoke.Threshold(img1, img1, (double)aThreshUpDownNumeric.Value, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                CvInvoke.Erode(img1, img1, element, p, (int)aErodeItersNumeric.Value, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(255, 255, 255));
                CvInvoke.Dilate(img1, img1, element, p, (int)aDilateItersNumeric.Value, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(255, 255, 255));

                // contours
                Mat h = new Mat();
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                contours.Clear();
                contourDataList.Clear();
                CvInvoke.FindContours(img1, contours, h, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                // collect contour stats in list of ContourData structures
                for (int i = 0; i < contours.Size; i++)
                {
                    int _key = i;
                    double _area = CvInvoke.ContourArea(contours[i]);
                    if (_area < 1000)
                    {
                        continue;
                    }
                    Rectangle _rect = CvInvoke.BoundingRectangle(contours[i]);
                    Moments _moments = CvInvoke.Moments(contours[i]);
                    RotatedRect _minRect = CvInvoke.MinAreaRect(contours[i]);
                    RotatedRect _ellipseRect = CvInvoke.FitEllipse(contours[i]);
                    _ellipseRect.Angle = 90 - _ellipseRect.Angle;
                    double _arcLength = CvInvoke.ArcLength(contours[i], isClosed: true);

                    contourDataList.Add(new ContourData(_key, _area, _rect, _minRect, _ellipseRect, _moments, _arcLength));
                }

                if (addObject)
                {
                    if (contourDataList.Count == 0)
                    {
                        Console.WriteLine("No objects in scene. " + objName + " cannot be added. Try again with object present.");
                        objName = "";
                        addObject = false;
                    }
                    else if (contourDataList.Count == 1)
                    {
                        ContourData newEntry = contourDataList[0];
                        newEntry.name = string.Copy(objName);
                        objectList.Add(newEntry);
                        objName = "";
                        addObject = false;
                        UpdateObjectList();
                    }
                    else if (contourDataList.Count > 1)
                    {
                        Console.WriteLine("Too many objects in scene. " + objName + " cannot be added. Try again with one object present.");
                        objName = "";
                        addObject = false;
                    }
                }

                if (contourDataList.Count >= 1)
                {
                    contourDataList.Sort((s1, s2) => s2.area.CompareTo(s1.area));
                    for (int i = 0; i < contourDataList.Count; i++)
                    {
                        double intensity = ((double)(i + 1) / (double)contourDataList.Count) * (double)255;
                        MCvScalar intense = new MCvScalar(intensity, 128, 255 - intensity);
                        CvInvoke.DrawContours(img2, contours, contourDataList[i].key, intense, thickness : 8);

                        if (objectList.Count >= 1)
                        {
                            (double d, string name) = Assign(contourDataList[i]);

                            if (showLabels)
                            {
                                if (d > 1.0)
                                {
                                    name += "?";
                                }
                                Point textLoc1 = new Point(contourDataList[i].centroid.X + 130, contourDataList[i].centroid.Y + 0);
                                CvInvoke.PutText(img2, name, textLoc1, Emgu.CV.CvEnum.FontFace.HersheyPlain, 4, intense, 4);
                            }

                            if (showDistanceMetric)
                            {
                                decimal d0 = (decimal)d;
                                string text = d0.ToString("0.##");
                                if (text.Length == 1)
                                {
                                    text += ".00";
                                }
                                text = "(" + text + ")";

                                Point textLoc2 = new Point(contourDataList[i].centroid.X + 130, contourDataList[i].centroid.Y + 50);
                                CvInvoke.PutText(img2, text, textLoc2, Emgu.CV.CvEnum.FontFace.HersheyPlain, 3, intense, 4);
                            }

                        }
                    }
                }

                aNumObjectsUpDownNumeric.Value = contourDataList.Count;
                imageBox2.Image = img2;
            }
        }

        public double[] GetFeatureVector(ContourData cd)
        {
            double[] featureVector = new double[]
            {
                cd.area / 4000.0,
                cd.eccentricity * 2.0,
                cd.arcLength / 300.0,

                cd.logHuMoments[0] / 2.0,
                cd.logHuMoments[1] / 8.0,
                cd.logHuMoments[2] / 8.0,
                cd.logHuMoments[3] / 8.0
                //cd.logHuMoments[4],
                //cd.logHuMoments[5]
                // cd.logHuMoments[6],
        };
            return featureVector;
        }

        public void UpdateObjectList()
        {
            // sort objectList by size (from biggest to smallest)
            objectList.Sort((s1, s2) => s2.area.CompareTo(s1.area));

            int n = objectList.Count;
            double[,] temp = new double[n, nFeatures];

            for (int i = 0; i < n; i++)
            {
                double[] features = GetFeatureVector(objectList[i]);
                for (int j = 0; j < nFeatures; j++)
                {
                    temp[i, j] = features[j];
                }
            }
            featureArray = temp.Clone() as double[,];
        }

        public (double, string) Assign(ContourData cd)
        {

            double[] features = GetFeatureVector(cd);

            int n = objectList.Count;
            double[] similarity = new double[n];

            for (int i = 0; i < n; i++)
            {
                double d = 0;
                for (int j = 0; j < features.Length; j++)
                {
                    d += Math.Pow(features[j] - featureArray[i, j], 2.0);
                }
                similarity[i] = Math.Sqrt(d);
            }

            double min = similarity.Min();
            int minIndex = Array.IndexOf(similarity, min);

            return (min, objectList[minIndex].name);
        }

        private void PrintArray(double[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write("\n\n");
            }
        }

        private void getBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            background = frameToBGR();
            backgroundSet = true;
        }

        private void closeCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aTimer.Enabled = false;
            cam0.CloseCamera();
        }

        private Image<Bgr, byte> frameToBGR()
        {
            (imgFrameNum, imgMat) = cam0.GetOneImage();
            imgSplitMat = imgMat.Split();
            blue = imgSplitMat[2].ToImage<Gray, byte>();
            green = imgSplitMat[1].ToImage<Gray, byte>();
            red = imgSplitMat[0].ToImage<Gray, byte>();
            grays[0] = blue;
            grays[1] = green;
            grays[2] = red;
            aFrameNumUpDown.Value = imgFrameNum;
            return new Image<Bgr, byte>(grays);
        }

        private void addObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string suggestInput = "target";
            objName = ShowInputDialog(ref suggestInput);
            addObject = true;            
        }


        private static string ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return input;
        }

        private void printObjectInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ContourData cd in objectList)
            {
                Console.WriteLine("Object Name:   {0}", cd.name);
            }
        }

        private void labelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showLabels == false)
            {
                showLabels = true;
            }
            else
            {
                showLabels = false;
            }
        }

        private void distanceMetricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showDistanceMetric == false)
            {
                showDistanceMetric = true;
            }
            else
            {
                showDistanceMetric = false;
            }
        }

        public void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string movement;
            Process pipeClient = new Process();
            pipeClient.StartInfo.FileName = @"C:\Users\JohnsonRobertEvan\UnityProjects\KitchFetch1\Build\KitchFetch1.exe";

            using (AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {
                Console.WriteLine("[SERVER] Current TransmissionMode: {0}", pipeServer.TransmissionMode);

                // pass the client process a handle to the server.
                pipeClient.StartInfo.Arguments = pipeServer.GetClientHandleAsString();
                pipeClient.StartInfo.UseShellExecute = false;
                pipeClient.Start();

                pipeServer.DisposeLocalCopyOfClientHandle();
                try
                {
                    // read user input and send that to the client process.
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;

                        for (int i = 0; i < 50; i++)
                        {
                            float x = NextFloat(5);
                            float z = NextFloat(3);
                            movement = x.ToString() + "," + z.ToString();
                            sw.WriteLine();
                            pipeServer.WaitForPipeDrain();
                            Console.WriteLine("movement:  {0}", movement);
                            Thread.Sleep(100);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("[SERVER] Error: {0}", ex.Message);
                }

                pipeClient.WaitForExit();
                pipeClient.Close();
                Console.WriteLine("[SERVER] Client quit. Server terminating.");
            }
            
        }

        static float NextFloat(float max)
        {
            var rand = new Random();
            double test = rand.NextDouble() * max;
            return (float)test;
        }
    }
}
