namespace Kitchen
{
    partial class Form1
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
            this.aOpenCamButton = new System.Windows.Forms.Button();
            this.aCloseCamButton = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.aTimer = new System.Windows.Forms.Timer(this.components);
            this.aFrameID = new System.Windows.Forms.NumericUpDown();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.histogramBox1 = new Emgu.CV.UI.HistogramBox();
            this.imageBox5 = new Emgu.CV.UI.ImageBox();
            this.aGetGackButton = new System.Windows.Forms.Button();
            this.imageBox6 = new Emgu.CV.UI.ImageBox();
            this.imageBox7 = new Emgu.CV.UI.ImageBox();
            this.aFrameNumLabel = new System.Windows.Forms.Label();
            this.aThreshLabel = new System.Windows.Forms.Label();
            this.aThreshUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.aErodeItersUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.aNumObjectsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.aDilateItersUpDown = new System.Windows.Forms.NumericUpDown();
            this.aCollectSamplesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aFrameID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aThreshUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aErodeItersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumObjectsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDilateItersUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // aOpenCamButton
            // 
            this.aOpenCamButton.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aOpenCamButton.Location = new System.Drawing.Point(12, 12);
            this.aOpenCamButton.Margin = new System.Windows.Forms.Padding(4);
            this.aOpenCamButton.Name = "aOpenCamButton";
            this.aOpenCamButton.Size = new System.Drawing.Size(224, 65);
            this.aOpenCamButton.TabIndex = 0;
            this.aOpenCamButton.Text = "Open Camera";
            this.aOpenCamButton.UseVisualStyleBackColor = true;
            this.aOpenCamButton.Click += new System.EventHandler(this.aOpenCamButton_Click);
            // 
            // aCloseCamButton
            // 
            this.aCloseCamButton.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aCloseCamButton.Location = new System.Drawing.Point(708, 12);
            this.aCloseCamButton.Margin = new System.Windows.Forms.Padding(4);
            this.aCloseCamButton.Name = "aCloseCamButton";
            this.aCloseCamButton.Size = new System.Drawing.Size(224, 65);
            this.aCloseCamButton.TabIndex = 4;
            this.aCloseCamButton.Text = "Close Camera";
            this.aCloseCamButton.UseVisualStyleBackColor = true;
            this.aCloseCamButton.Click += new System.EventHandler(this.aCloseCamButton_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(20, 96);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(2000, 962);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // aTimer
            // 
            this.aTimer.Interval = 1;
            this.aTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // aFrameID
            // 
            this.aFrameID.Location = new System.Drawing.Point(1343, 46);
            this.aFrameID.Margin = new System.Windows.Forms.Padding(4);
            this.aFrameID.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.aFrameID.Name = "aFrameID";
            this.aFrameID.Size = new System.Drawing.Size(160, 31);
            this.aFrameID.TabIndex = 5;
            // 
            // imageBox2
            // 
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.Location = new System.Drawing.Point(2030, 96);
            this.imageBox2.Margin = new System.Windows.Forms.Padding(6);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(640, 308);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox3.Location = new System.Drawing.Point(2030, 423);
            this.imageBox3.Margin = new System.Windows.Forms.Padding(6);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(640, 308);
            this.imageBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox3.TabIndex = 6;
            this.imageBox3.TabStop = false;
            // 
            // imageBox4
            // 
            this.imageBox4.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox4.Location = new System.Drawing.Point(2030, 750);
            this.imageBox4.Margin = new System.Windows.Forms.Padding(6);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(640, 308);
            this.imageBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox4.TabIndex = 7;
            this.imageBox4.TabStop = false;
            // 
            // histogramBox1
            // 
            this.histogramBox1.Location = new System.Drawing.Point(2682, 96);
            this.histogramBox1.Margin = new System.Windows.Forms.Padding(12);
            this.histogramBox1.Name = "histogramBox1";
            this.histogramBox1.Size = new System.Drawing.Size(596, 962);
            this.histogramBox1.TabIndex = 8;
            // 
            // imageBox5
            // 
            this.imageBox5.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox5.Location = new System.Drawing.Point(20, 1073);
            this.imageBox5.Margin = new System.Windows.Forms.Padding(6);
            this.imageBox5.Name = "imageBox5";
            this.imageBox5.Size = new System.Drawing.Size(993, 623);
            this.imageBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox5.TabIndex = 9;
            this.imageBox5.TabStop = false;
            // 
            // aGetGackButton
            // 
            this.aGetGackButton.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aGetGackButton.Location = new System.Drawing.Point(244, 12);
            this.aGetGackButton.Margin = new System.Windows.Forms.Padding(4);
            this.aGetGackButton.Name = "aGetGackButton";
            this.aGetGackButton.Size = new System.Drawing.Size(224, 65);
            this.aGetGackButton.TabIndex = 10;
            this.aGetGackButton.Text = "Get Gackground";
            this.aGetGackButton.UseVisualStyleBackColor = true;
            this.aGetGackButton.Click += new System.EventHandler(this.aGetGackButton_Click);
            // 
            // imageBox6
            // 
            this.imageBox6.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox6.Location = new System.Drawing.Point(1027, 1073);
            this.imageBox6.Margin = new System.Windows.Forms.Padding(6);
            this.imageBox6.Name = "imageBox6";
            this.imageBox6.Size = new System.Drawing.Size(993, 623);
            this.imageBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox6.TabIndex = 11;
            this.imageBox6.TabStop = false;
            // 
            // imageBox7
            // 
            this.imageBox7.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox7.Location = new System.Drawing.Point(2032, 1073);
            this.imageBox7.Margin = new System.Windows.Forms.Padding(6);
            this.imageBox7.Name = "imageBox7";
            this.imageBox7.Size = new System.Drawing.Size(993, 623);
            this.imageBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox7.TabIndex = 12;
            this.imageBox7.TabStop = false;
            // 
            // aFrameNumLabel
            // 
            this.aFrameNumLabel.AutoSize = true;
            this.aFrameNumLabel.Location = new System.Drawing.Point(1361, 17);
            this.aFrameNumLabel.Name = "aFrameNumLabel";
            this.aFrameNumLabel.Size = new System.Drawing.Size(123, 25);
            this.aFrameNumLabel.TabIndex = 13;
            this.aFrameNumLabel.Text = "Frame Num";
            // 
            // aThreshLabel
            // 
            this.aThreshLabel.AutoSize = true;
            this.aThreshLabel.Location = new System.Drawing.Point(1518, 17);
            this.aThreshLabel.Name = "aThreshLabel";
            this.aThreshLabel.Size = new System.Drawing.Size(146, 25);
            this.aThreshLabel.TabIndex = 15;
            this.aThreshLabel.Text = "Binary Thresh";
            // 
            // aThreshUpDown
            // 
            this.aThreshUpDown.Location = new System.Drawing.Point(1511, 46);
            this.aThreshUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.aThreshUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aThreshUpDown.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.aThreshUpDown.Name = "aThreshUpDown";
            this.aThreshUpDown.Size = new System.Drawing.Size(160, 31);
            this.aThreshUpDown.TabIndex = 14;
            this.aThreshUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1686, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "# Erode Iters";
            // 
            // aErodeItersUpDown
            // 
            this.aErodeItersUpDown.Location = new System.Drawing.Point(1679, 46);
            this.aErodeItersUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.aErodeItersUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aErodeItersUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aErodeItersUpDown.Name = "aErodeItersUpDown";
            this.aErodeItersUpDown.Size = new System.Drawing.Size(160, 31);
            this.aErodeItersUpDown.TabIndex = 16;
            this.aErodeItersUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2022, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "# of Objects";
            // 
            // aNumObjectsUpDown
            // 
            this.aNumObjectsUpDown.Location = new System.Drawing.Point(2015, 46);
            this.aNumObjectsUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.aNumObjectsUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aNumObjectsUpDown.Name = "aNumObjectsUpDown";
            this.aNumObjectsUpDown.Size = new System.Drawing.Size(160, 31);
            this.aNumObjectsUpDown.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1854, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "# Dilate Iters";
            // 
            // aDilateItersUpDown
            // 
            this.aDilateItersUpDown.Location = new System.Drawing.Point(1847, 47);
            this.aDilateItersUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.aDilateItersUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aDilateItersUpDown.Name = "aDilateItersUpDown";
            this.aDilateItersUpDown.Size = new System.Drawing.Size(160, 31);
            this.aDilateItersUpDown.TabIndex = 20;
            this.aDilateItersUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // aCollectSamplesButton
            // 
            this.aCollectSamplesButton.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aCollectSamplesButton.Location = new System.Drawing.Point(476, 12);
            this.aCollectSamplesButton.Margin = new System.Windows.Forms.Padding(4);
            this.aCollectSamplesButton.Name = "aCollectSamplesButton";
            this.aCollectSamplesButton.Size = new System.Drawing.Size(224, 65);
            this.aCollectSamplesButton.TabIndex = 22;
            this.aCollectSamplesButton.Text = "Collect Samples";
            this.aCollectSamplesButton.UseVisualStyleBackColor = true;
            this.aCollectSamplesButton.Click += new System.EventHandler(this.aCollectSamplesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3319, 1877);
            this.Controls.Add(this.aCollectSamplesButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aDilateItersUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aNumObjectsUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aErodeItersUpDown);
            this.Controls.Add(this.aThreshLabel);
            this.Controls.Add(this.aThreshUpDown);
            this.Controls.Add(this.aFrameNumLabel);
            this.Controls.Add(this.imageBox7);
            this.Controls.Add(this.imageBox6);
            this.Controls.Add(this.aGetGackButton);
            this.Controls.Add(this.imageBox5);
            this.Controls.Add(this.histogramBox1);
            this.Controls.Add(this.imageBox4);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.aFrameID);
            this.Controls.Add(this.aCloseCamButton);
            this.Controls.Add(this.aOpenCamButton);
            this.Controls.Add(this.imageBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aFrameID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aThreshUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aErodeItersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumObjectsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDilateItersUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aOpenCamButton;
        private System.Windows.Forms.Button aCloseCamButton;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Timer aTimer;
        private System.Windows.Forms.NumericUpDown aFrameID;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private Emgu.CV.UI.ImageBox imageBox4;
        private Emgu.CV.UI.HistogramBox histogramBox1;
        private Emgu.CV.UI.ImageBox imageBox5;
        private System.Windows.Forms.Button aGetGackButton;
        private Emgu.CV.UI.ImageBox imageBox6;
        private Emgu.CV.UI.ImageBox imageBox7;
        private System.Windows.Forms.Label aFrameNumLabel;
        private System.Windows.Forms.Label aThreshLabel;
        private System.Windows.Forms.NumericUpDown aThreshUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown aErodeItersUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown aNumObjectsUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown aDilateItersUpDown;
        private System.Windows.Forms.Button aCollectSamplesButton;
    }
}

