namespace Kitchen
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectSamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.golfballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.momentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printObjectInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showObjectInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceMetricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aTimer = new System.Windows.Forms.Timer(this.components);
            this.aFrameNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aThreshUpDownNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.aErodeItersNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.aDilateItersNumeric = new System.Windows.Forms.NumericUpDown();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label5 = new System.Windows.Forms.Label();
            this.aNumObjectsUpDownNumeric = new System.Windows.Forms.NumericUpDown();
            this.unityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aFrameNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aThreshUpDownNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aErodeItersNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDilateItersNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumObjectsUpDownNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.Location = new System.Drawing.Point(10, 50);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(1200, 600);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sVMToolStripMenuItem,
            this.momentsToolStripMenuItem,
            this.unityToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2296, 42);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCameraToolStripMenuItem,
            this.getBackgroundToolStripMenuItem,
            this.closeCameraToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(116, 38);
            this.fileToolStripMenuItem.Text = "Camera";
            // 
            // openCameraToolStripMenuItem
            // 
            this.openCameraToolStripMenuItem.Name = "openCameraToolStripMenuItem";
            this.openCameraToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            this.openCameraToolStripMenuItem.Text = "Open Camera";
            this.openCameraToolStripMenuItem.Click += new System.EventHandler(this.openCameraToolStripMenuItem_Click);
            // 
            // getBackgroundToolStripMenuItem
            // 
            this.getBackgroundToolStripMenuItem.Name = "getBackgroundToolStripMenuItem";
            this.getBackgroundToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            this.getBackgroundToolStripMenuItem.Text = "Get Background";
            this.getBackgroundToolStripMenuItem.Click += new System.EventHandler(this.getBackgroundToolStripMenuItem_Click);
            // 
            // closeCameraToolStripMenuItem
            // 
            this.closeCameraToolStripMenuItem.Name = "closeCameraToolStripMenuItem";
            this.closeCameraToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            this.closeCameraToolStripMenuItem.Text = "Close Camera";
            this.closeCameraToolStripMenuItem.Click += new System.EventHandler(this.closeCameraToolStripMenuItem_Click);
            // 
            // sVMToolStripMenuItem
            // 
            this.sVMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectSamplesToolStripMenuItem,
            this.fitModelToolStripMenuItem});
            this.sVMToolStripMenuItem.Name = "sVMToolStripMenuItem";
            this.sVMToolStripMenuItem.Size = new System.Drawing.Size(85, 38);
            this.sVMToolStripMenuItem.Text = "SVM";
            // 
            // collectSamplesToolStripMenuItem
            // 
            this.collectSamplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baseballToolStripMenuItem,
            this.golfballToolStripMenuItem});
            this.collectSamplesToolStripMenuItem.Name = "collectSamplesToolStripMenuItem";
            this.collectSamplesToolStripMenuItem.Size = new System.Drawing.Size(318, 44);
            this.collectSamplesToolStripMenuItem.Text = "Collect Samples";
            // 
            // baseballToolStripMenuItem
            // 
            this.baseballToolStripMenuItem.Name = "baseballToolStripMenuItem";
            this.baseballToolStripMenuItem.Size = new System.Drawing.Size(236, 44);
            this.baseballToolStripMenuItem.Text = "baseball";
            // 
            // golfballToolStripMenuItem
            // 
            this.golfballToolStripMenuItem.Name = "golfballToolStripMenuItem";
            this.golfballToolStripMenuItem.Size = new System.Drawing.Size(236, 44);
            this.golfballToolStripMenuItem.Text = "golfball";
            // 
            // fitModelToolStripMenuItem
            // 
            this.fitModelToolStripMenuItem.Name = "fitModelToolStripMenuItem";
            this.fitModelToolStripMenuItem.Size = new System.Drawing.Size(318, 44);
            this.fitModelToolStripMenuItem.Text = "Fit Model";
            // 
            // momentsToolStripMenuItem
            // 
            this.momentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectToolStripMenuItem,
            this.printObjectInfoToolStripMenuItem,
            this.showObjectInfoToolStripMenuItem});
            this.momentsToolStripMenuItem.Name = "momentsToolStripMenuItem";
            this.momentsToolStripMenuItem.Size = new System.Drawing.Size(137, 38);
            this.momentsToolStripMenuItem.Text = "Moments";
            // 
            // addObjectToolStripMenuItem
            // 
            this.addObjectToolStripMenuItem.Name = "addObjectToolStripMenuItem";
            this.addObjectToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.addObjectToolStripMenuItem.Text = "Add Object";
            this.addObjectToolStripMenuItem.Click += new System.EventHandler(this.addObjectToolStripMenuItem_Click);
            // 
            // printObjectInfoToolStripMenuItem
            // 
            this.printObjectInfoToolStripMenuItem.Name = "printObjectInfoToolStripMenuItem";
            this.printObjectInfoToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.printObjectInfoToolStripMenuItem.Text = "Print Object Info";
            this.printObjectInfoToolStripMenuItem.Click += new System.EventHandler(this.printObjectInfoToolStripMenuItem_Click);
            // 
            // showObjectInfoToolStripMenuItem
            // 
            this.showObjectInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelsToolStripMenuItem,
            this.distanceMetricToolStripMenuItem});
            this.showObjectInfoToolStripMenuItem.Name = "showObjectInfoToolStripMenuItem";
            this.showObjectInfoToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.showObjectInfoToolStripMenuItem.Text = "Show Object Info";
            // 
            // labelsToolStripMenuItem
            // 
            this.labelsToolStripMenuItem.Name = "labelsToolStripMenuItem";
            this.labelsToolStripMenuItem.Size = new System.Drawing.Size(315, 44);
            this.labelsToolStripMenuItem.Text = "Labels";
            this.labelsToolStripMenuItem.Click += new System.EventHandler(this.labelsToolStripMenuItem_Click);
            // 
            // distanceMetricToolStripMenuItem
            // 
            this.distanceMetricToolStripMenuItem.Name = "distanceMetricToolStripMenuItem";
            this.distanceMetricToolStripMenuItem.Size = new System.Drawing.Size(315, 44);
            this.distanceMetricToolStripMenuItem.Text = "Distance Metric";
            this.distanceMetricToolStripMenuItem.Click += new System.EventHandler(this.distanceMetricToolStripMenuItem_Click);
            // 
            // aTimer
            // 
            this.aTimer.Interval = 5;
            this.aTimer.Tick += new System.EventHandler(this.aTimer_Tick);
            // 
            // aFrameNumUpDown
            // 
            this.aFrameNumUpDown.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aFrameNumUpDown.Location = new System.Drawing.Point(1216, 50);
            this.aFrameNumUpDown.Maximum = new decimal(new int[] {
            410065408,
            2,
            0,
            0});
            this.aFrameNumUpDown.Name = "aFrameNumUpDown";
            this.aFrameNumUpDown.Size = new System.Drawing.Size(148, 39);
            this.aFrameNumUpDown.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1370, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Frame Num";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1370, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 36);
            this.label2.TabIndex = 8;
            this.label2.Text = "Binary Thresh";
            // 
            // aThreshUpDownNumeric
            // 
            this.aThreshUpDownNumeric.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aThreshUpDownNumeric.Location = new System.Drawing.Point(1216, 95);
            this.aThreshUpDownNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aThreshUpDownNumeric.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.aThreshUpDownNumeric.Name = "aThreshUpDownNumeric";
            this.aThreshUpDownNumeric.Size = new System.Drawing.Size(148, 38);
            this.aThreshUpDownNumeric.TabIndex = 7;
            this.aThreshUpDownNumeric.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1370, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 36);
            this.label3.TabIndex = 10;
            this.label3.Text = "# Erode Iters";
            // 
            // aErodeItersNumeric
            // 
            this.aErodeItersNumeric.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aErodeItersNumeric.Location = new System.Drawing.Point(1216, 139);
            this.aErodeItersNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aErodeItersNumeric.Name = "aErodeItersNumeric";
            this.aErodeItersNumeric.Size = new System.Drawing.Size(148, 39);
            this.aErodeItersNumeric.TabIndex = 9;
            this.aErodeItersNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1370, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 36);
            this.label4.TabIndex = 12;
            this.label4.Text = "# Dilate Iters";
            // 
            // aDilateItersNumeric
            // 
            this.aDilateItersNumeric.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aDilateItersNumeric.Location = new System.Drawing.Point(1216, 184);
            this.aDilateItersNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aDilateItersNumeric.Name = "aDilateItersNumeric";
            this.aDilateItersNumeric.Size = new System.Drawing.Size(148, 39);
            this.aDilateItersNumeric.TabIndex = 11;
            this.aDilateItersNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // imageBox2
            // 
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.Location = new System.Drawing.Point(10, 660);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(1200, 600);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 13;
            this.imageBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1370, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 36);
            this.label5.TabIndex = 15;
            this.label5.Text = "# Objects";
            // 
            // aNumObjectsUpDownNumeric
            // 
            this.aNumObjectsUpDownNumeric.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aNumObjectsUpDownNumeric.Location = new System.Drawing.Point(1216, 229);
            this.aNumObjectsUpDownNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aNumObjectsUpDownNumeric.Name = "aNumObjectsUpDownNumeric";
            this.aNumObjectsUpDownNumeric.Size = new System.Drawing.Size(148, 39);
            this.aNumObjectsUpDownNumeric.TabIndex = 14;
            // 
            // unityToolStripMenuItem
            // 
            this.unityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServerToolStripMenuItem});
            this.unityToolStripMenuItem.Name = "unityToolStripMenuItem";
            this.unityToolStripMenuItem.Size = new System.Drawing.Size(91, 38);
            this.unityToolStripMenuItem.Text = "Unity";
            // 
            // startServerToolStripMenuItem
            // 
            this.startServerToolStripMenuItem.Name = "startServerToolStripMenuItem";
            this.startServerToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.startServerToolStripMenuItem.Text = "Start Server";
            this.startServerToolStripMenuItem.Click += new System.EventHandler(this.startServerToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2296, 1284);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.aNumObjectsUpDownNumeric);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.aDilateItersNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aErodeItersNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aThreshUpDownNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aFrameNumUpDown);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aFrameNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aThreshUpDownNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aErodeItersNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDilateItersNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumObjectsUpDownNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer aTimer;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectSamplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem golfballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitModelToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown aFrameNumUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown aThreshUpDownNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown aErodeItersNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown aDilateItersNumeric;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown aNumObjectsUpDownNumeric;
        private System.Windows.Forms.ToolStripMenuItem momentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printObjectInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showObjectInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanceMetricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServerToolStripMenuItem;
    }
}