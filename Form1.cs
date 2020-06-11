
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Kitchen
{
    public partial class Form1 : Form
    {
        public BFCamera cam0;

        Image<Gray, byte> red;
        Image<Gray, byte> green;
        Image<Gray, byte> blue;
        Image<Gray, byte>[] grayList;
        Image<Bgr, byte> bgrImage;

        Image<Bgr, byte> background;
        Image<Gray, byte> backBlue;
        Image<Gray, byte> backGreen;
        Image<Gray, byte> backRed;
        bool backgroundSet = false;
        bool collectingCCSamples = false;
        int nSamples = 0;
        int nBatches = 0;

        Image<Gray, byte> imgCC;
        CCStatsOp[] statsOp;
        MCvPoint2D64f[] centroidPoints;
        double[,] statArray = new double[200, 9];

        public struct CCStatsOp
        {
            public Rectangle Rectangle;
            public int Area;
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void aOpenCamButton_Click(object sender, EventArgs e)
        {
            cam0 = new BFCamera(this);
            cam0.OpenCamera();
            aTimer.Enabled = true;
        }

        private void aCloseCamButton_Click(object sender, EventArgs e)
        {
            aTimer.Enabled = false;
            cam0.CloseCamera();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var (frameID, mat) = cam0.GetOneImage();
            Mat[] splitMat = mat.Split();

            red = splitMat[0].ToImage<Gray, byte>();
            green = splitMat[1].ToImage<Gray, byte>();
            blue = splitMat[2].ToImage<Gray, byte>();
            grayList = new Image<Gray, byte>[] { blue, green, red };
            bgrImage = new Image<Bgr, byte>(grayList);

            
            aFrameID.Value = frameID;

            imageBox2.Image = blue;
            imageBox3.Image = green;
            imageBox4.Image = red;

            histogramBox1.ClearHistogram();
            histogramBox1.GenerateHistograms(bgrImage, 128);
            histogramBox1.Refresh();

            if (backgroundSet)
            {
                // thresold and erode image
                Image<Gray, byte> temp = bgrImage.AbsDiff(background).Convert<Gray, byte>();
                CvInvoke.Threshold(temp, temp, (double)aThreshUpDown.Value, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                temp = temp.Erode((int)aErodeItersUpDown.Value).Dilate((int)aDilateItersUpDown.Value);

                Mat imgLabel = new Mat();
                Mat stats = new Mat();
                Mat centroids = new Mat();
                

                var nLabels = CvInvoke.ConnectedComponentsWithStats(temp, imgLabel, stats, centroids);

                imgCC = imgLabel.ToImage<Gray, byte>();
                centroidPoints = new MCvPoint2D64f[nLabels];
                centroids.CopyTo(centroidPoints);
                statsOp = new CCStatsOp[nLabels];
                stats.CopyTo(statsOp);
                aNumObjectsUpDown.Value = nLabels - 1;

                // collect 10 samples from single object (should be largest object in foreground)
                if (collectingCCSamples)
                {
                    if (nLabels == 1)
                    {
                        Console.WriteLine("No object found");
                    }
                    else if (nLabels >= 3)
                    {
                        Console.WriteLine("More than one foreground object found");
                    }
                    else
                    {
                        double area = statsOp[1].Area;
                        double aspectRatio = (double)statsOp[1].Rectangle.Height / (double)statsOp[1].Rectangle.Width;
                        double density = (double)area / ((double)statsOp[1].Rectangle.Width * (double)statsOp[1].Rectangle.Height);
                        var mask = imgCC.InRange(new Gray(1), new Gray(1));
                        // imageBox7.Image = mask;

                        MCvScalar meanCC = new MCvScalar();
                        MCvScalar stdCC = new MCvScalar();
                        CvInvoke.MeanStdDev(bgrImage, ref meanCC, ref stdCC, mask);
                        Console.WriteLine("sample: {0}, area: {1}, density: {2}, aspect: {3}",
                            nSamples.ToString(), area.ToString(), density.ToString(), aspectRatio.ToString());

                        statArray[nSamples, 0] = area;
                        statArray[nSamples, 1] = aspectRatio;
                        statArray[nSamples, 2] = density;
                        statArray[nSamples, 3] = meanCC.V0;
                        statArray[nSamples, 4] = meanCC.V1;
                        statArray[nSamples, 5] = meanCC.V2;
                        statArray[nSamples, 6] = stdCC.V0;
                        statArray[nSamples, 7] = stdCC.V1;
                        statArray[nSamples, 8] = stdCC.V2;
                    }

                    nSamples++;
                    if (nSamples >= 20)
                    {
                        nSamples = 0;
                        collectingCCSamples = false;

                        int rowLength = statArray.GetLength(0);
                        int colLength = statArray.GetLength(1);

                        for (int i = 0; i < rowLength; i++)
                        {
                            for (int j = 0; j < colLength; j++)
                            {
                                Console.Write(string.Format("{0} ", statArray[i, j]));
                            }
                            Console.Write("\n");
                        }
                        nBatches++;
                        if (nBatches >= 10)
                        {
                            // put code here
                        }
                    }
                }

                if (nLabels > 1)
                {
                    imageBox6.Image = imgCC * (255 / (nLabels - 1));
                }

                imageBox5.Image = temp;

                //// get contours
                //VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                //Mat hier = new Mat();
                //CvInvoke.FindContours(temp, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                //// sort by area of bounding rectangle
                //Dictionary<int, double> dict = new Dictionary<int, double>();

                //if (contours.Size > 0)
                //{
                //    for (int i = 0; i < contours.Size; i++)
                //    {
                //        double area = CvInvoke.ContourArea(contours[i]);
                //        dict.Add(i, area);
                //    }
                //}

                //var item = dict.OrderByDescending(v => v.Value);

                //foreach (var it in item)
                //{
                //    int key = int.Parse(it.Key.ToString());
                //    CvInvoke.DrawContours(bgrImage, contours, key, new MCvScalar(128, 0, 255), 4);
                //}
            }

            imageBox1.Image = bgrImage;
        }

        private void aGetGackButton_Click(object sender, EventArgs e)
        {
            var (_, mat) = cam0.GetOneImage();
            Mat[] splitMat = mat.Split();

            backRed = splitMat[0].ToImage<Gray, byte>();
            backGreen = splitMat[1].ToImage<Gray, byte>();
            backBlue = splitMat[2].ToImage<Gray, byte>();
            grayList = new Image<Gray, byte>[] { blue, green, red };
            background = new Image<Bgr, byte>(grayList);
            backgroundSet = true;
        }

        private void aCollectSamplesButton_Click(object sender, EventArgs e)
        {
            collectingCCSamples = true;
        }
    }
}
