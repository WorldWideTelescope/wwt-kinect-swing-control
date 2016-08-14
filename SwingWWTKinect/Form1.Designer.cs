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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.AngleDisplay.Location = new System.Drawing.Point(1122, 43);
            this.AngleDisplay.Name = "AngleDisplay";
            this.AngleDisplay.Size = new System.Drawing.Size(70, 25);
            this.AngleDisplay.TabIndex = 2;
            this.AngleDisplay.Text = "label1";
            // 
            // reverse
            // 
            this.reverse.AutoSize = true;
            this.reverse.Location = new System.Drawing.Point(1118, 153);
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
            this.label1.Location = new System.Drawing.Point(1078, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Top";
            // 
            // topSliceEdit
            // 
            this.topSliceEdit.Location = new System.Drawing.Point(1083, 278);
            this.topSliceEdit.Name = "topSliceEdit";
            this.topSliceEdit.Size = new System.Drawing.Size(100, 31);
            this.topSliceEdit.TabIndex = 5;
            this.topSliceEdit.TextChanged += new System.EventHandler(this.topSliceEdit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1078, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bottom";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BottomSliceEdit
            // 
            this.BottomSliceEdit.Location = new System.Drawing.Point(1083, 369);
            this.BottomSliceEdit.Name = "BottomSliceEdit";
            this.BottomSliceEdit.Size = new System.Drawing.Size(100, 31);
            this.BottomSliceEdit.TabIndex = 5;
            this.BottomSliceEdit.TextChanged += new System.EventHandler(this.BottomSliceEdit_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1511, 988);
            this.Controls.Add(this.BottomSliceEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topSliceEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reverse);
            this.Controls.Add(this.AngleDisplay);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}

