using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using MathNet.Numerics.LinearRegression;
using Point = System.Drawing.Point;

namespace WWFOC
{
    public class ImageProcessor
    {
        
        private readonly List<Target> _targets = new List<Target>();
        
        public ImageProcessor(Bitmap source, bool debug = false)
        {
            Source = source;
            Debug = debug;
        }

        public Bitmap Source { get; }

        public bool Debug { get; }

        public ImageProcessorOutput Process()
        {
            return new ImageProcessorOutput()
            {
                Images = CreateOutputs(),
                Title = "Title",
                Targets = _targets
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
            
            var median = new Median(7).Apply(image);
            result.Add(new ImageOutput(median, "Median"));
            
            var medianCv = new Image<Gray, byte>(median);
            var dil = medianCv.Dilate(3);
            Bitmap dilBitMap = dil.Bitmap.Clone(new Rectangle(Point.Empty, dil.Bitmap.Size), PixelFormat.Format32bppRgb);
            result.Add(new ImageOutput(dilBitMap, "Dilated"));

            var colorFiltered = FilterRange(dilBitMap);
            result.Add(new ImageOutput(colorFiltered, "Color filtered"));

            var colorFilteredCv = new Image<Gray, byte>(colorFiltered);
            var cannyCv = colorFilteredCv.Canny(280, 80);
            result.Add(new ImageOutput(cannyCv.ToBitmap(), "Contours"));
            
            Bitmap bm = DrawFinal(cannyCv, colorFilteredCv, image);

            result.Add(new ImageOutput(bm, "Final"));
            return result;
        }

        private Bitmap DrawFinal(Image<Gray, byte> cannyCv, Image<Gray, byte> colorFilteredCv, Bitmap background)
        {
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(cannyCv, contours, hierarchy, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);
            Histogram hist = new ImageStatistics(colorFilteredCv.Bitmap).Gray;
            if (contours.Size >= 250 || hist.Median > 50) // Image contains too much noise 
                return background;

            Bitmap bm = new Bitmap(colorFilteredCv.Width, colorFilteredCv.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.DrawImage(background, Point.Empty);
                Pen p = new Pen(Color.Red) {Width = 2};
                for (int i = 0; i < contours.Size; i++)
                {
                    VectorOfPoint contour = contours[i];
                    int[] hierarchyData = Helpers.GetHierarchy(hierarchy, i);
                    double contourArea = CvInvoke.ContourArea(contour);
                    if (contourArea > 280 && contourArea < 4000
                                          && hierarchyData[3] == -1)
                    {
                        if (Helpers.CalculateCircularity(contour) > 0.45)
                        {
                            if (Helpers.CalculateColorDifference(colorFilteredCv, contour) > 0)
                            {
                                _targets.Add(new Target(CvInvoke.MinEnclosingCircle(contour).Center));
                                for (int i2 = 1; i2 < contour.Size; i2++)
                                {
                                    Point p1 = contour[i2 - 1];
                                    Point p2 = contour[i2];
                                    g.DrawLine(p, p1, p2);
                                }

                                g.DrawLine(p, contour[0], contour[contour.Size - 1]);
                            }
                        }
                    }
                }
                
                // line demo
                //cannyCv.HoughLinesBinary(Math.PI / 180, )
                
            }

            return bm;
        }

        private Bitmap FilterRange(Bitmap image)
        {
            ContrastCorrection cc = new ContrastCorrection(20);
            /*ImageStatistics stat = new ImageStatistics( image );
            Histogram grayhist = stat.Red;
            LevelsLinear ll = new LevelsLinear
            {
                Input = new IntRange(50, 200),
                Output = new IntRange(0, 255)
            };
            return ll.Apply(cc.Apply(image));*/
            return cc.Apply(image);
        }
        
        private static Bitmap CreateGrayscale(Bitmap image)
        {
            
            const int size = 512;
            float scale = Math.Min(size / (float)image.Width, size / (float)image.Height);
            ResizeBicubic resize = new ResizeBicubic((int)(image.Width*scale), (int)(image.Height*scale));
            
            ImageStatistics stat = new ImageStatistics( image );
            LevelsLinear levelsLinear = new LevelsLinear
            {
                Output = new IntRange(0, 255),
                InRed = stat.Red.GetRange(.95),
                InBlue = stat.Blue.GetRange(.95),
                InGreen = stat.Green.GetRange(.95)
            };
            SaturationCorrection sc = new SaturationCorrection(-1);
            Bitmap resized = resize.Apply(sc.Apply(levelsLinear.Apply(image)).MakeGrayscale());
            Bitmap square = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(square))
            {
                g.DrawImage(resized, new Point((size-resized.Width) / 2 ,0));
            }
            
            return square;
        }
    }
}