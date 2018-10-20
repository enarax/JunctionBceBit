using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.ComplexFilters;
using AForge.Imaging.Filters;
using Dicom;
using Dicom.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Point = System.Drawing.Point;

namespace WWFOC
{
    public partial class Form1 : Form
    {

        public string SourcePath { get; set; } = @"C:\Users\marce\OneDrive\Junction\Dataset2\339663";
        public string SourceFileName = "MR.339663.Image 33.dcm";

        public Bitmap ImageToDraw { get; set; }

        public int DetectionParam1 { get; set; } = 100;
        public int DetectionParam2 { get; set; } = 100;
        public int DetectionMaxRadius { get; set; } = 0;
        
        
        public Form1()
        {
            InitializeComponent();
            trackBarP1.Value = DetectionParam1;
            trackBarP2.Value = DetectionParam2;
            trackBarMaxRadius.Value = DetectionMaxRadius;
            Load += OnLoad;
            imageHolder.Paint += ImageHolderOnPaint;
            trackBarP1.Scroll += (sender, args) => { DetectionParam1 = trackBarP1.Value; Redraw(); };
            trackBarP2.Scroll += (sender, args) => { DetectionParam2 = trackBarP2.Value; Redraw(); };
            trackBarMaxRadius.Scroll += (sender, args) => { DetectionMaxRadius = trackBarMaxRadius.Value; Redraw(); };
        }

        public void Redraw()
        {
            imageHolder.Invalidate();
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
            DicomFile sourceFile = await DicomFile.OpenAsync(Path.Combine(SourcePath, SourceFileName));
            Bitmap original = new DicomImage(sourceFile.Dataset).RenderImage().AsClonedBitmap();
            
            
            
            ImageToDraw = TransformImage(original);
        }

        private Bitmap TransformImage(Bitmap original)
        {
            Bitmap image = CreateGrayscale(original);
            /*ComplexImage ci = ComplexImage.FromBitmap(image);
            ci.ForwardFourierTransform();
            FrequencyFilter ff = new FrequencyFilter(new IntRange(10, Int32.MaxValue));
            ff.Apply(ci);
            ci.BackwardFourierTransform();
            image = ci.ToBitmap();*/
            
            
            new Median(2).ApplyInPlace(image);

            image = Detect(image);

            return image;
        }

        private Bitmap Detect(Bitmap image)
        {
            var inputArray = new Image<Gray, byte>(image);
            var circles = CvInvoke.HoughCircles(inputArray, HoughType.Gradient, 1, 5, DetectionParam1, DetectionParam2, 0, maxRadius: DetectionMaxRadius);
            
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(image, Point.Empty);
                Pen p = new Pen(Color.Red);
                foreach (CircleF circleF in circles)
                {
                    g.DrawEllipse(p, circleF.Center.X-circleF.Radius, circleF.Center.Y-circleF.Radius, circleF.Radius*2, circleF.Radius*2);
                }
            }

            

            return bm;
        }

        private static Bitmap CreateGrayscale(Bitmap original)
        {
            
            ImageStatistics stat = new ImageStatistics( original );
            LevelsLinear levelsLinear = new LevelsLinear();
            levelsLinear.Output = new IntRange(0, 255);
            levelsLinear.InRed = stat.Red.GetRange(.95);
            levelsLinear.InBlue = stat.Blue.GetRange(.95);
            levelsLinear.InGreen = stat.Green.GetRange(.95);
            SaturationCorrection sc = new SaturationCorrection(-1);
            Bitmap image = sc.Apply(levelsLinear.Apply(original)).MakeGrayscale();
            return image;
        }
    }
}