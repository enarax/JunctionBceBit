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
            this.tabViewer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDebug = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxRadius)).BeginInit();
            this.tabViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarP1
            // 
            this.trackBarP1.LargeChange = 10;
            this.trackBarP1.Location = new System.Drawing.Point(22, 13);
            this.trackBarP1.Maximum = 400;
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
            this.trackBarP2.Maximum = 400;
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
            // tabViewer
            // 
            this.tabViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabViewer.Controls.Add(this.tabPage1);
            this.tabViewer.Controls.Add(this.tabPage2);
            this.tabViewer.Location = new System.Drawing.Point(0, 75);
            this.tabViewer.Name = "tabViewer";
            this.tabViewer.SelectedIndex = 0;
            this.tabViewer.Size = new System.Drawing.Size(729, 513);
            this.tabViewer.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(721, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(721, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDebug
            // 
            this.buttonDebug.Location = new System.Drawing.Point(592, 28);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(75, 23);
            this.buttonDebug.TabIndex = 5;
            this.buttonDebug.Text = "DEBUG";
            this.buttonDebug.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 588);
            this.Controls.Add(this.buttonDebug);
            this.Controls.Add(this.tabViewer);
            this.Controls.Add(this.trackBarMaxRadius);
            this.Controls.Add(this.trackBarP2);
            this.Controls.Add(this.trackBarP1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxRadius)).EndInit();
            this.tabViewer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBarP1;
        private System.Windows.Forms.TrackBar trackBarP2;
        private System.Windows.Forms.TrackBar trackBarMaxRadius;
        private System.Windows.Forms.TabControl tabViewer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonDebug;
    }
}

