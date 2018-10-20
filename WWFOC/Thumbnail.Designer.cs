namespace WWFOC
{
    partial class Thumbnail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbx_image = new System.Windows.Forms.PictureBox();
            this.lbl_text = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_image
            // 
            this.pbx_image.Location = new System.Drawing.Point(3, 3);
            this.pbx_image.Name = "pbx_image";
            this.pbx_image.Size = new System.Drawing.Size(220, 183);
            this.pbx_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_image.TabIndex = 0;
            this.pbx_image.TabStop = false;
            // 
            // lbl_text
            // 
            this.lbl_text.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.lbl_text.Location = new System.Drawing.Point(3, 189);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(223, 32);
            this.lbl_text.TabIndex = 3;
            this.lbl_text.Text = "_filename";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Thumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.pbx_image);
            this.Name = "Thumbnail";
            this.Size = new System.Drawing.Size(226, 231);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_image;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
