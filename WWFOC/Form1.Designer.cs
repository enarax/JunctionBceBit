namespace WWFOC
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
            this.trackBarP1 = new System.Windows.Forms.TrackBar();
            this.trackBarP2 = new System.Windows.Forms.TrackBar();
            this.trackBarMaxRadius = new System.Windows.Forms.TrackBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarP1
            // 
            this.trackBarP1.LargeChange = 10;
            this.trackBarP1.Location = new System.Drawing.Point(22, 13);
            this.trackBarP1.Maximum = 200;
            this.trackBarP1.Minimum = 10;
            this.trackBarP1.Name = "trackBarP1";
            this.trackBarP1.Size = new System.Drawing.Size(172, 45);
            this.trackBarP1.SmallChange = 5;
            this.trackBarP1.TabIndex = 1;
            this.trackBarP1.TickFrequency = 20;
            this.trackBarP1.Value = 100;
            // 
            // trackBarP2
            // 
            this.trackBarP2.LargeChange = 10;
            this.trackBarP2.Location = new System.Drawing.Point(200, 12);
            this.trackBarP2.Maximum = 200;
            this.trackBarP2.Minimum = 10;
            this.trackBarP2.Name = "trackBarP2";
            this.trackBarP2.Size = new System.Drawing.Size(172, 45);
            this.trackBarP2.SmallChange = 5;
            this.trackBarP2.TabIndex = 2;
            this.trackBarP2.TickFrequency = 20;
            this.trackBarP2.Value = 100;
            // 
            // trackBarMaxRadius
            // 
            this.trackBarMaxRadius.LargeChange = 10;
            this.trackBarMaxRadius.Location = new System.Drawing.Point(378, 12);
            this.trackBarMaxRadius.Maximum = 200;
            this.trackBarMaxRadius.Name = "trackBarMaxRadius";
            this.trackBarMaxRadius.Size = new System.Drawing.Size(172, 45);
            this.trackBarMaxRadius.SmallChange = 5;
            this.trackBarMaxRadius.TabIndex = 3;
            this.trackBarMaxRadius.TickFrequency = 20;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 64);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(705, 512);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 588);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.trackBarMaxRadius);
            this.Controls.Add(this.trackBarP2);
            this.Controls.Add(this.trackBarP1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBarP1;
        private System.Windows.Forms.TrackBar trackBarP2;
        private System.Windows.Forms.TrackBar trackBarMaxRadius;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

