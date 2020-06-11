using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using Emgu.CV.OCR;

namespace Kitchen
{
    public class BFCamera
    {
        public ManagedSystem system;
        public ManagedCameraList camList;
        public IManagedCamera managedCam;
        public INodeMap nodeMapTLDevice;
        public INodeMap nodeMapTLStream;
        public INodeMap nodeMap;
        public string filePath;
        public Form2 form;
        public Size frameSize;
        public Mat cvMat;

        ManagedImage convertedImage = new ManagedImage();

        public BFCamera(Form2 _form)
        {
            form = _form;
            filePath = "C:\\Users\\JohnsonRobertEvan\\CSharpProjects\\Kitchen\\data";
        }

        public void OpenCamera()
        {
            // Get system, camera list, and camera (single camera only)
            system = new ManagedSystem();
            camList = system.GetCameras();
            managedCam = camList[0];

            // Get nodemaps and initialize camera
            nodeMapTLDevice = managedCam.GetTLDeviceNodeMap();
            nodeMapTLStream = managedCam.GetTLStreamNodeMap();

            managedCam.Init();
            nodeMap = managedCam.GetNodeMap();

            // Adjust camera settings and save to file
            CameraSettings camSettings = new CameraSettings(managedCam, nodeMapTLDevice, nodeMapTLStream, nodeMap);
            camSettings.saveSettings();
            frameSize = camSettings.GetFrameSize();
            managedCam.BeginAcquisition();
        }

        public unsafe (int, Mat) GetOneImage()
        {
            int frameID;
            try
            {
                using(IManagedImage rawImage = managedCam.GetNextImage())
                {
                    rawImage.Convert(convertedImage, PixelFormatEnums.RGB8);
                    IntPtr point = convertedImage.DataPtr;
                    int width = (int)convertedImage.Width;
                    int height = (int)convertedImage.Height;
                    frameID = (int)rawImage.ChunkData.FrameID;
                    Size frameSize = new Size(width, height);
                    cvMat = new Mat(frameSize, default, 3, point, width);
                    rawImage.Release();
                }
                return (frameID, cvMat);
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:  " + ex.Message);
                return (0, new Mat());
            }
        }

        public void CloseCamera(bool _factoryReset = false)
        {
            managedCam.EndAcquisition();

            if (_factoryReset)
            {
                ICommand iFactoryReset = nodeMap.GetNode<ICommand>("FactoryReset");
                iFactoryReset.Execute();
            }
            else
            {
                managedCam.DeInit();
            }

            // Clear camera list and release system.
            camList.Clear();
            system.Dispose();
            Console.WriteLine("\nSystem released.");
        }
    }
}
