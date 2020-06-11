using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography.X509Certificates;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;

namespace Kitchen
{
    public class CameraSettings
    {
        private IManagedCamera cam;
        private INodeMap nodeMapTLDevice;
        private INodeMap nodeMapTLStream;
        private INodeMap nodeMap;
        private Size frameSize;

        private string settingsTextFile = "C:\\Users\\JohnsonRobertEvan\\CSharpProjects\\" +
            "Kitchen\\data\\camera_settings.txt";

        // Limit line length in settingsTextFile
        const int MaxChars = 35;

        public enum NodeTypeEnum
        {
            StringNode,
            IntegerNode,
            FloatNode,
            BoolNode,
            CommandNode,
            EnumerationNode
        };

        public enum NodeMapEnum
        {
            GenICam,
            TLDevice,
            TLStream
        }

        // Constructor
        public CameraSettings(IManagedCamera _cam,
                              INodeMap _nodeMapTLDevice,
                              INodeMap _nodeMapTLStream,
                              INodeMap _nodeMap)
        {
            cam = _cam;
            nodeMapTLDevice = _nodeMapTLDevice;
            nodeMapTLStream = _nodeMapTLStream;
            nodeMap = _nodeMap;

            // Array of tuples define camera settings to change.
            // Order matters. This list will be iterated through.
            var settingsToSet = new (string, string, int)[]
            {
                ("AcquisitionFrameRateEnable", "true", (int)NodeTypeEnum.BoolNode),
                ("AcquisitionFrameRate", "60.0", (int)NodeTypeEnum.FloatNode),
                ("DeviceLinkThroughputLimit", "500000000", (int)NodeTypeEnum.IntegerNode),
                ("Width", "2000", (int)NodeTypeEnum.IntegerNode),
                ("Height", "1000", (int)NodeTypeEnum.IntegerNode),
                ("ExposureAuto", "Off", (int)NodeTypeEnum.EnumerationNode),
                ("ExposureMode", "Timed", (int)NodeTypeEnum.EnumerationNode),
                ("ExposureTime", "7000.0", (int)NodeTypeEnum.FloatNode),
                ("GainAuto", "Off", (int)NodeTypeEnum.EnumerationNode),
                ("Gain", "30.0", (int)NodeTypeEnum.FloatNode),
                ("PixelFormat", "BayerRG8", (int)NodeTypeEnum.EnumerationNode)
            };

            // Iterate through camera settings and set them.
            foreach (var setting in settingsToSet)
            {
                SetSettings(setting.Item1, setting.Item2, setting.Item3, NodeMapEnum.GenICam);
            }

            var settingsToSetTL = new (string, string, int)[]
            {
                ("StreamBufferHandlingMode", "NewestOnly", (int)NodeTypeEnum.EnumerationNode)
            };

            foreach (var setting in settingsToSetTL)
            {
                SetSettings(setting.Item1, setting.Item2, setting.Item3, NodeMapEnum.TLStream);
            }

            // Center the image on the sensor
            CenterROI();

            // Enable Chunk Data in image
            EnableChunkData();
        }

        public void CenterROI()
        {
            long width = nodeMap.GetNode<IInteger>("Width").Value;
            long height = nodeMap.GetNode<IInteger>("Height").Value;
            frameSize = new Size((int)width, (int)height);

            long widthMax = nodeMap.GetNode<IInteger>("WidthMax").Value;
            long heightMax = nodeMap.GetNode<IInteger>("HeightMax").Value;
            long offsetX = (widthMax - width) / 2;
            long offsetY = ((heightMax - height) / 2) - 130; // not currently centered. Specific for kitchen prototype.

            nodeMap.GetNode<IInteger>("OffsetX").Value = offsetX;
            nodeMap.GetNode<IInteger>("OffsetY").Value = offsetY;
        }

        public void EnableChunkData()
        {
            cam.ChunkSelector.Value = ChunkSelectorEnums.Timestamp.ToString();
            cam.ChunkEnable.Value = true;
            cam.ChunkModeActive.Value = true;

            cam.ChunkSelector.Value = ChunkSelectorEnums.FrameID.ToString();
            cam.ChunkEnable.Value = true;
            cam.ChunkModeActive.Value = true;
        }

        public Size GetFrameSize()
        {
            return frameSize;
        }

        public void SetSettings(string _setting, string _settingValue, int _nodeType, NodeMapEnum _nodeMap)
        {
            if (_nodeType == (int)NodeTypeEnum.StringNode)
            {
                // Get string node
                IString iNode = null;
                if (_nodeMap == NodeMapEnum.GenICam)
                {
                    iNode = nodeMap.GetNode<IString>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLDevice)
                {
                    iNode = nodeMapTLDevice.GetNode<IString>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLStream)
                {
                    iNode = nodeMapTLStream.GetNode<IString>(_setting);
                }

                // Get current value
                string currentValue = iNode.Value.ToString();

                // Set new value
                iNode.Value = _settingValue;

                // Confirm new value is set
                string newValue = iNode.Value.ToString();

                // Print using local print function
                printSettingChangeInfo(currentValue, newValue);
            }
            else if (_nodeType == (int)NodeTypeEnum.IntegerNode)
            {
                // Get integer node
                IInteger iNode = null;
                if (_nodeMap == NodeMapEnum.GenICam)
                {
                    iNode = nodeMap.GetNode<IInteger>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLDevice)
                {
                    iNode = nodeMapTLDevice.GetNode<IInteger>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLStream)
                {
                    iNode = nodeMapTLStream.GetNode<IInteger>(_setting);
                }

                // Get current value
                string currentValue = iNode.Value.ToString();

                // Set new value
                iNode.Value = Convert.ToInt32(_settingValue);

                // Confirm new value is set
                string newValue = iNode.Value.ToString();

                // Print using local print function
                printSettingChangeInfo(currentValue, newValue);
            }
            else if (_nodeType == (int)NodeTypeEnum.FloatNode)
            {
                // Get float node
                IFloat iNode = null;
                if (_nodeMap == NodeMapEnum.GenICam)
                {
                    iNode = nodeMap.GetNode<IFloat>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLDevice)
                {
                    iNode = nodeMapTLDevice.GetNode<IFloat>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLStream)
                {
                    iNode = nodeMapTLStream.GetNode<IFloat>(_setting);
                }

                // Get current value
                string currentValue = iNode.Value.ToString();

                // Set new value
                iNode.Value = float.Parse(_settingValue, CultureInfo.InvariantCulture.NumberFormat);

                // Confirm new value is set
                string newValue = iNode.Value.ToString();

                // Print using local print function
                printSettingChangeInfo(currentValue, newValue);
            }
            else if (_nodeType == (int)NodeTypeEnum.BoolNode)
            {
                // Get bool node
                IBool iNode = null;
                if (_nodeMap == NodeMapEnum.GenICam)
                {
                    iNode = nodeMap.GetNode<IBool>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLDevice)
                {
                    iNode = nodeMapTLDevice.GetNode<IBool>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLStream)
                {
                    iNode = nodeMapTLStream.GetNode<IBool>(_setting);
                }

                // Get current value
                string currentValue = iNode.Value.ToString();

                // Set new value
                iNode.Value = Convert.ToBoolean(_settingValue);

                // Confirm new value is set
                string newValue = iNode.Value.ToString();

                // Print using local print function
                printSettingChangeInfo(currentValue, newValue);
            }
            else if (_nodeType == (int)NodeTypeEnum.CommandNode)
            {
                // Get command node
                ICommand iNode = nodeMap.GetNode<ICommand>(_setting);

                Console.WriteLine("Command to be executed: {0}", _setting);

                // Execute command
                iNode.Execute();
            }
            else if (_nodeType == (int)NodeTypeEnum.EnumerationNode)
            {
                // Get enumeration node
                IEnum iNode = null;
                if (_nodeMap == NodeMapEnum.GenICam)
                {
                    iNode = nodeMap.GetNode<IEnum>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLDevice)
                {
                    iNode = nodeMapTLDevice.GetNode<IEnum>(_setting);
                }
                else if (_nodeMap == NodeMapEnum.TLStream)
                {
                    iNode = nodeMapTLStream.GetNode<IEnum>(_setting);
                }

                // Get EnumEntry node
                IEnumEntry iEntry = iNode.GetEntryByName(_settingValue);

                // Get current value
                string currentValue = iEntry.Symbolic.ToString();

                // Change EnumEntry value for corresponding enumeration node
                iNode.Value = iEntry.Symbolic;

                // Confirm new value is set
                string newValue = iEntry.Symbolic.ToString();

                // Print using local print function
                printSettingChangeInfo(currentValue, newValue);
            }

            void printSettingChangeInfo(string _currentValue, string _newValue)
            {
                Console.WriteLine("{0} ({1}) changed from {2} to {3}",
                    _setting, (NodeTypeEnum)_nodeType, _currentValue, _newValue);
            }
        }

        string indent(int level)
        {
            StringBuilder sb = new StringBuilder("");

            for (int i = 0; i < level; i++)
            {
                sb.Append("   ");
            }
            return sb.ToString();
        }

        // Retrieve display name and value of string node.
        private void PrintStringNode(INode node, int level, StreamWriter sw)
        {
            try
            {
                // Cast as string node
                IString iStringNode = (IString)node;

                // Retrieve display name
                string displayName = iStringNode.DisplayName;

                // Retrieve string node value
                string value = iStringNode.Value;

                // Check length is not excessive for printing
                if (value.Length > MaxChars)
                {
                    value = value.Substring(0, MaxChars) + "...";
                }

                sw.WriteLine(indent(level) + displayName + ":  " + value + "  (String Node)");
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:   " + ex.ToString());
            }
        }

        private void PrintIntegerNode(INode node, int level, StreamWriter sw)
        {
            try
            {
                // Cast node as integer node
                IInteger iIntegerNode = (IInteger)node;

                // Retrieve display name
                string displayName = iIntegerNode.DisplayName;

                // Retrieve integer node value
                long value = iIntegerNode.Value;

                sw.WriteLine(indent(level) + displayName + ":  " + value.ToString() + "  (Integer Node)");
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:   " + ex.ToString());
            }
        }

        private void PrintFloatNode(INode node, int level, StreamWriter sw)
        {
            try
            {
                // Cast node as integer node
                IFloat iFloatNode = (IFloat)node;

                // Retrieve display name
                string displayName = iFloatNode.DisplayName;

                // Retrieve integer node value
                double value = iFloatNode.Value;

                sw.WriteLine(indent(level) + displayName + ":  " + value.ToString() + "  (Float Node)");
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:   " + ex.ToString());
            }
        }

        private void PrintBooleanNode(INode node, int level, StreamWriter sw)
        {
            try
            {
                // Cast as boolean node
                IBool iBooleanNode = (IBool)node;

                // Retrieve display name
                string displayName = iBooleanNode.DisplayName;

                // Retrieve value as a string representation
                string value = (iBooleanNode.Value ? "true" : "false");

                sw.WriteLine(indent(level) + displayName + ":  " + value + "  (Bool Node)");
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:   " + ex.ToString());
            }
        }

        private void PrintCommandNode(INode node, int level, StreamWriter sw)
        {
            try
            {
                // Cast as command node
                ICommand iCommandNode = (ICommand)node;

                // Retrieve display name
                string displayName = iCommandNode.DisplayName;

                // Retrieve tooltip
                string tooltip = iCommandNode.ToolTip;

                // Ensure that the value length is not excessive for printing
                if (tooltip.Length > MaxChars)
                {
                    tooltip = tooltip.Substring(0, MaxChars) + "...";
                }
                sw.WriteLine(indent(level) + displayName + ":  " + tooltip + "  (Command Node)");
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:   " + ex.ToString());
            }
        }

        private void PrintEnumerationNodeAndCurrentEntry(INode node, int level, StreamWriter sw)
        {
            try
            {
                // Cast as enumeration node
                IEnum iEnumerationNode = (IEnum)node;

                // Retrieve current entry as enumeration node
                EnumValue iEnumEntryValue = iEnumerationNode.Value;

                // Retrieve display name
                string displayName = iEnumerationNode.DisplayName;

                // Retrieve current symbolic
                string currentEntrySymbolic = iEnumEntryValue.String;

                sw.WriteLine(indent(level) + displayName + ":  " + currentEntrySymbolic + "  (Enumeration Node)");
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:   " + ex.ToString());
            }
        }

        private void PrintCategoryNodeAndAllFeatures(INode node, int level, StreamWriter sw)
        {
            try
            {
                // Cast as category node
                ICategory iCategoryNode = (ICategory)node;

                // Retrieve display name
                string displayName = iCategoryNode.DisplayName;

                sw.WriteLine(indent(level) + displayName + "  (Category Node)");

                // Retrieve children
                //
                // *** NOTES ***
                // The two nodes that typically have children are category nodes
                // and enumeration nodes. Throughout the examples, the children
                // of category nodes are referred to as features while the
                // children of enumeration nodes are referred to as entries.
                // Keep in mind that enumeration nodes can be cast as category
                // nodes, but category nodes cannot be cast as enumerations.
                //
                INode[] features = iCategoryNode.Features;

                // Iterate through all children
                foreach (INode iFeatureNode in features)
                {
                    // Ensure node is available and readable
                    if (!iFeatureNode.IsAvailable || !iFeatureNode.IsReadable)
                    {
                        continue;
                    }

                    // Category nodes must be dealt with separately in order to
                    // retrieve subnodes recursively.
                    if (iFeatureNode.GetType() == typeof(Category))
                    {
                        PrintCategoryNodeAndAllFeatures(iFeatureNode, level + 1, sw);
                    }
                    else if (iFeatureNode.GetType() == typeof(StringReg))
                    {
                        PrintStringNode(iFeatureNode, level + 1, sw);
                    }
                    else if (iFeatureNode.GetType() == typeof(Integer))
                    {
                        PrintIntegerNode(iFeatureNode, level + 1, sw);
                    }
                    else if (iFeatureNode.GetType() == typeof(Float))
                    {
                        PrintFloatNode(iFeatureNode, level + 1, sw);
                    }
                    else if (iFeatureNode.GetType() == typeof(BoolNode))
                    {
                        PrintBooleanNode(iFeatureNode, level + 1, sw);
                    }
                    else if (iFeatureNode.GetType() == typeof(Command))
                    {
                        PrintCommandNode(iFeatureNode, level + 1, sw);
                    }
                    else if (iFeatureNode.GetType() == typeof(Enumeration))
                    {
                        PrintEnumerationNodeAndCurrentEntry(iFeatureNode, level + 1, sw);
                    }
                }
                sw.WriteLine();
            }
            catch (SpinnakerException ex)
            {
                Console.WriteLine("Error:   " + ex.ToString());
            }
        }


        public void saveSettings(bool _printSettings = false)
        {
            try
            {
                // Check if file already exists. If yes, delete it.
                if (File.Exists(settingsTextFile))
                {
                    File.Delete(settingsTextFile);
                }

                // Create a new file.
                using (StreamWriter sw = File.CreateText(settingsTextFile))
                {
                    int level = 0;

                    try
                    {
                        sw.WriteLine("\n*** TRANSPORT LAYER DEVICE NODEMAP ***\n");
                        PrintCategoryNodeAndAllFeatures(nodeMapTLDevice.GetNode<ICategory>("Root"), level, sw);

                        sw.WriteLine("\n*** TRANSPORT LAYER STREAM NODEMAP ***\n");
                        PrintCategoryNodeAndAllFeatures(nodeMapTLStream.GetNode<ICategory>("Root"), level, sw);

                        sw.WriteLine("\n*** GENICAM NODEMAP ***\n");
                        PrintCategoryNodeAndAllFeatures(nodeMap.GetNode<ICategory>("Root"), level, sw);
                    }
                    catch (SpinnakerException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.ToString());
                    }
                }

                // Write file contents on console if desired.     
                if (_printSettings)
                {
                    using (StreamReader sr = File.OpenText(settingsTextFile))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
