using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dicom;
using Dicom.Imaging;

namespace WWFOC
{
    public partial class Form1 : Form
    {

        public string SourcePath { get; set; } = "C:/Users/marce/OneDrive/Junction/Dataset/386348";

        public int SourceFrame { get; set; } = 69;

        public Bitmap ImageToDraw { get; set; }
        
        
        public Form1()
        {
            InitializeComponent();
            Load += OnLoad;
            imageHolder.Paint += ImageHolderOnPaint;
        }

        private void ImageHolderOnPaint(object sender, PaintEventArgs e)
        {
            float targetHeight = e.Graphics.VisibleClipBounds.Height;
            float targetWidth = e.Graphics.VisibleClipBounds.Width;
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new RectangleF(0, 0, targetWidth, targetHeight));
            
            if (ImageToDraw != null)
            {
                // resize if needed
                if (!(Math.Abs(ImageToDraw.Height - targetHeight) < 2) &&
                    !(Math.Abs(ImageToDraw.Width - targetWidth) < 2))
                {
                    float scale = Math.Min(targetWidth / ImageToDraw.Width, targetHeight / ImageToDraw.Height);
                    var scaleWidth = (int)(ImageToDraw.Width * scale);
                    var scaleHeight = (int)(ImageToDraw.Height * scale);
                    e.Graphics.DrawImage(ImageToDraw, ((int)targetWidth - scaleWidth)/2, ((int)targetHeight - scaleHeight)/2, scaleWidth, scaleHeight);
                }
                else
                {
                    e.Graphics.DrawImage(ImageToDraw, 0, 0);
                }
                
            }
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            DicomFile sourceFile = await DicomFile.OpenAsync(Path.Combine(SourcePath, "MR.386348.Image 96.dcm"));
            ImageToDraw = new DicomImage(sourceFile.Dataset).RenderImage().AsClonedBitmap();
        }
    }
}