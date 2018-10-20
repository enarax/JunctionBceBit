using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
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
using Emgu.CV.Util;
using Point = System.Drawing.Point;

namespace WWFOC
{
    public partial class Form1 : Form
    {

        public string SourcePath { get; set; } = @"C:\Users\marce\OneDrive\Junction\Dataset2\339663";
        public string SourceFileName = "MR.339663.Image 33.dcm";


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
            trackBarP1.MouseUp += async (sender, args) => { DetectionParam1 = trackBarP1.Value; await UpdateImageAsync(); };
            trackBarP2.MouseUp += async (sender, args) => { DetectionParam2 = trackBarP2.Value; await UpdateImageAsync(); };
            trackBarMaxRadius.MouseUp += async (sender, args) => { DetectionMaxRadius = trackBarMaxRadius.Value; await UpdateImageAsync(); };
        }

        public void ClearImages()
        {    
            Invoke((MethodInvoker) delegate {
                tabViewer.TabPages.Clear();
            });
        }

        public void PostImage(Bitmap bm, string title)
        {
            Invoke((MethodInvoker) delegate
            {
                TabPage page = new TabPage(title);
                PictureBox pb = new PictureBox
                {
                    Image = bm.Clone(new RectangleF(PointF.Empty, bm.Size), PixelFormat.Format32bppRgb), 
                    Dock = DockStyle.Fill, 
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                page.Controls.Add(pb);
                tabViewer.TabPages.Add(page);
            });
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            await UpdateImageAsync();
        }

        private async Task UpdateImageAsync()
        {
            DicomFile sourceFile = await DicomFile.OpenAsync(Path.Combine(SourcePath, SourceFileName));
            Bitmap original = new DicomImage(sourceFile.Dataset).RenderImage().AsClonedBitmap();

            ClearImages();
            await Task.Run(() => { 
                TransformImage(original);
            });
            tabViewer.SelectedIndex = tabViewer.TabCount - 1;
        }

        private void TransformImage(Bitmap original)
        {
            Bitmap image = CreateGrayscale(original);
            PostImage(image, "Greyscale");
            /*ComplexImage ci = ComplexImage.FromBitmap(image);
            ci.ForwardFourierTransform();
            FrequencyFilter ff = new FrequencyFilter(new IntRange(10, Int32.MaxValue));
            ff.Apply(ci);
            ci.BackwardFourierTransform();
            image = ci.ToBitmap();*/
            
            
            image = new Median(2).Apply(image);
            PostImage(image, "Median");

            image = Detect(image);

            PostImage(image, "Final");
        }

        private Bitmap Detect(Bitmap image)
        {
            var inputArray = new Image<Gray, byte>(image);
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            var dil = inputArray.Dilate(3);
            PostImage(dil.ToBitmap(), "Dilated");
            dil = dil.Canny(DetectionParam1, DetectionParam2);
            PostImage(dil.ToBitmap(), "Contours");
            CvInvoke.FindContours(dil, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(dil.ToBitmap(), Point.Empty);
                Pen p = new Pen(Color.Red);
                foreach (Point[] contour in contours.ToArrayOfArray()    )
                {
                    for (int i = 1; i < contour.Length; i++)
                    {
                        Point p1 = contour[i - 1];
                        Point p2 = contour[i];
                        g.DrawLine(p, p1, p2);
                    }
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