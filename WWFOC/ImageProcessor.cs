using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Point = System.Drawing.Point;

namespace WWFOC
{
    public class ImageProcessor
    {
        public ImageProcessor(Bitmap source, int parameter1, int parameter2, int parameter3)
        {
            Source = source;
            Parameter1 = parameter1;
            Parameter2 = parameter2;
            Parameter3 = parameter3;
        }

        public Bitmap Source { get; }
        
        public int Parameter1 { get; }
        
        public int Parameter2 { get; }
        
        public int Parameter3 { get; }

        public ImageProcessorOutput Process()
        {
            return new ImageProcessorOutput()
            {
                Images = CreateOutputs(),
                Title = "Title"
            };
        }

        private IReadOnlyList<ImageOutput> CreateOutputs()
        {
            List<ImageOutput> result = new List<ImageOutput>();
            Bitmap image = CreateGrayscale(Source);
            result.Add(new ImageOutput(image, "Grayscale"));
            /*ComplexImage ci = ComplexImage.FromBitmap(image);
            ci.ForwardFourierTransform();
            FrequencyFilter ff = new FrequencyFilter(new IntRange(10, Int32.MaxValue));
            ff.Apply(ci);
            ci.BackwardFourierTransform();
            image = ci.ToBitmap();*/
            
            image = new Median(2).Apply(image);
            result.Add(new ImageOutput(image, "Median"));
            
            var inputArray = new Image<Gray, byte>(image);
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            var dil = inputArray.Dilate(3);
            result.Add(new ImageOutput(dil.ToBitmap(), "Dilated"));
            
            dil = dil.Canny(Parameter1, Parameter2);
            result.Add(new ImageOutput(dil.ToBitmap(), "Contours"));
            
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
            
            result.Add(new ImageOutput(bm, "Final"));
            return result;
        }
        
        
        
        private static Bitmap CreateGrayscale(Bitmap original)
        {
            
            ImageStatistics stat = new ImageStatistics( original );
            LevelsLinear levelsLinear = new LevelsLinear
            {
                Output = new IntRange(0, 255),
                InRed = stat.Red.GetRange(.95),
                InBlue = stat.Blue.GetRange(.95),
                InGreen = stat.Green.GetRange(.95)
            };
            SaturationCorrection sc = new SaturationCorrection(-1);
            Bitmap image = sc.Apply(levelsLinear.Apply(original)).MakeGrayscale();
            return image;
        }
    }
}