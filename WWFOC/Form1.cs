using System;
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
using Point = System.Drawing.Point;

namespace WWFOC
{
    public partial class Form1 : Form
    {

        public string SourcePath { get; set; } = @"C:\Users\marce\OneDrive\Junction\Dataset2\339663";
        public string SourceFileName = "MR.339663.Image 33.dcm";
        private Bitmap _imageToDraw;

        public Bitmap ImageToDraw
        {
            get => _imageToDraw;
            set
            {
                _imageToDraw = value;
                this.Invoke((MethodInvoker)delegate { pictureBox.Image = value; });
            }
        }

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

        private async void OnLoad(object sender, EventArgs e)
        {
            await UpdateImageAsync();
        }

        private async Task UpdateImageAsync()
        {
            DicomFile sourceFile = await DicomFile.OpenAsync(Path.Combine(SourcePath, SourceFileName));
            Bitmap original = new DicomImage(sourceFile.Dataset).RenderImage().AsClonedBitmap();

            await Task.Run(() => { ImageToDraw = TransformImage(original); });
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