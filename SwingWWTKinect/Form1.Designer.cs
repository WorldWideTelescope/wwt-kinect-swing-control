namespace SwingWWTKinect
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AngleDisplay = new System.Windows.Forms.Label();
            this.reverse = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.topSliceEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BottomSliceEdit = new System.Windows.Forms.TextBox();
            this.Preview = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Amplitude = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectRope = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LightingSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amplitude)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1042, 932);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // AngleDisplay
            // 
            this.AngleDisplay.AutoSize = true;
            this.AngleDisplay.Location = new System.Drawing.Point(1078, 12);
            this.AngleDisplay.Name = "AngleDisplay";
            this.AngleDisplay.Size = new System.Drawing.Size(103, 25);
            this.AngleDisplay.TabIndex = 2;
            this.AngleDisplay.Text = "Angle: 90";
            // 
            // reverse
            // 
            this.reverse.AutoSize = true;
            this.reverse.Location = new System.Drawing.Point(1083, 56);
            this.reverse.Name = "reverse";
            this.reverse.Size = new System.Drawing.Size(124, 29);
            this.reverse.TabIndex = 3;
            this.reverse.Text = "Reverse";
            this.reverse.UseVisualStyleBackColor = true;
            this.reverse.CheckedChanged += new System.EventHandler(this.reverse_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1078, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Top";
            // 
            // topSliceEdit
            // 
            this.topSliceEdit.Location = new System.Drawing.Point(1083, 144);
            this.topSliceEdit.Name = "topSliceEdit";
            this.topSliceEdit.Size = new System.Drawing.Size(100, 31);
            this.topSliceEdit.TabIndex = 5;
            this.topSliceEdit.TextChanged += new System.EventHandler(this.topSliceEdit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1078, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bottom";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BottomSliceEdit
            // 
            this.BottomSliceEdit.Location = new System.Drawing.Point(1083, 235);
            this.BottomSliceEdit.Name = "BottomSliceEdit";
            this.BottomSliceEdit.Size = new System.Drawing.Size(100, 31);
            this.BottomSliceEdit.TabIndex = 5;
            this.BottomSliceEdit.TextChanged += new System.EventHandler(this.BottomSliceEdit_TextChanged);
            // 
            // Preview
            // 
            this.Preview.AutoSize = true;
            this.Preview.Location = new System.Drawing.Point(1083, 293);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(120, 29);
            this.Preview.TabIndex = 6;
            this.Preview.Text = "Preview";
            this.Preview.UseVisualStyleBackColor = true;
            this.Preview.CheckedChanged += new System.EventHandler(this.Preview_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1061, 723);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(438, 97);
            this.label3.TabIndex = 7;
            this.label3.Text = "Created as a collaboration between lab212, MuDA, American Asctronomical Society a" +
    "nd Microsoft";
            // 
            // Amplitude
            // 
            this.Amplitude.Location = new System.Drawing.Point(1083, 392);
            this.Amplitude.Maximum = 100;
            this.Amplitude.Minimum = 1;
            this.Amplitude.Name = "Amplitude";
            this.Amplitude.Size = new System.Drawing.Size(381, 90);
            this.Amplitude.TabIndex = 8;
            this.Amplitude.TickFrequency = 10;
            this.Amplitude.Value = 40;
            this.Amplitude.ValueChanged += new System.EventHandler(this.Aplitude_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1083, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Swing Aplitude";
            // 
            // SelectRope
            // 
            this.SelectRope.AutoSize = true;
            this.SelectRope.Location = new System.Drawing.Point(1088, 462);
            this.SelectRope.Name = "SelectRope";
            this.SelectRope.Size = new System.Drawing.Size(251, 29);
            this.SelectRope.TabIndex = 10;
            this.SelectRope.Text = "Select Rope Distance";
            this.SelectRope.UseVisualStyleBackColor = true;
            this.SelectRope.CheckedChanged += new System.EventHandler(this.SelectRope_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1083, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 11;
            this.button1.Text = "Lights On";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1260, 561);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 41);
            this.button2.TabIndex = 12;
            this.button2.Text = "Lights Off";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LightingSettings
            // 
            this.LightingSettings.Location = new System.Drawing.Point(1083, 634);
            this.LightingSettings.Name = "LightingSettings";
            this.LightingSettings.Size = new System.Drawing.Size(315, 41);
            this.LightingSettings.TabIndex = 13;
            this.LightingSettings.Text = "Lighting Settings";
            this.LightingSettings.UseVisualStyleBackColor = true;
            this.LightingSettings.Click += new System.EventHandler(this.LightingSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1511, 988);
            this.Controls.Add(this.LightingSettings);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SelectRope);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Amplitude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.BottomSliceEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topSliceEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reverse);
            this.Controls.Add(this.AngleDisplay);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "WorldWide Telescope Kinect Swing Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amplitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label AngleDisplay;
        private System.Windows.Forms.CheckBox reverse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox topSliceEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BottomSliceEdit;
        private System.Windows.Forms.CheckBox Preview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar Amplitude;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SelectRope;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button LightingSettings;
    }
}

