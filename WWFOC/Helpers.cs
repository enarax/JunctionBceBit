using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Util;

namespace WWFOC
{
    public static class Helpers
    {
        public static Bitmap MakeGrayscale(this Bitmap original)
        {
            var result = new Bitmap(original.Width, original.Height, PixelFormat.Format8bppIndexed);

            BitmapData data = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            // Copy the bytes from the image into a byte array
            byte[] bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);

            for (int y = 0; y < original.Height; y++) {
                for (int x = 0; x < original.Width; x++) {
                    var c = original.GetPixel(x, y);
                    var rgb = (byte)((c.R + c.G + c.B) / 3);

                    bytes[y * data.Stride + x] = rgb;
                }
            }

            // Copy the bytes from the byte array into the image
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);

            result.UnlockBits(data);
            
            ColorPalette newPalette = result.Palette;
            for (int index = 0; index < result.Palette.Entries.Length; ++index) {
                var entry = result.Palette.Entries[index];
                var gray = (int) (index / (double) result.Palette.Entries.Length * 255.0);
                newPalette.Entries[index] = Color.FromArgb(gray, gray, gray);
            }
            result.Palette = newPalette;    // Yes, assignment to self is intended

            return result;
        }
        
        public static int[] GetHierarchy(Mat hierarchy, int contourIdx)
        {
            int[] ret = new int[] { };

            if (hierarchy.Depth != Emgu.CV.CvEnum.DepthType.Cv32S)
            {
                throw new ArgumentOutOfRangeException("ContourData must have Cv32S hierarchy element type.");
            }
            if (hierarchy.Rows != 1)
            {
                throw new ArgumentOutOfRangeException("ContourData must have one hierarchy hierarchy row.");
            }
            if (hierarchy.NumberOfChannels != 4)
            {
                throw new ArgumentOutOfRangeException("ContourData must have four hierarchy channels.");
            }
            if (hierarchy.Dims != 2)
            {
                throw new ArgumentOutOfRangeException("ContourData must have two dimensional hierarchy.");
            }
            long elementStride = hierarchy.ElementSize / sizeof(Int32);
            var offset0 = (long)0 + contourIdx * elementStride;
            if (0 <= offset0 && offset0 < hierarchy.Total.ToInt64() * elementStride)
            {


                var offset1 = (long)1 + contourIdx * elementStride;
                var offset2 = (long)2 + contourIdx * elementStride;
                var offset3 = (long)3 + contourIdx * elementStride;

                ret = new int[4];

                unsafe
                {
                    //return *((Int32*)Hierarchy.DataPointer.ToPointer() + offset);

                    ret[0] = *((Int32*)hierarchy.DataPointer.ToPointer() + offset0);
                    ret[1] = *((Int32*)hierarchy.DataPointer.ToPointer() + offset1);
                    ret[2] = *((Int32*)hierarchy.DataPointer.ToPointer() + offset2);
                    ret[3] = *((Int32*)hierarchy.DataPointer.ToPointer() + offset3);
                }


            }
            //else
            //{
            //    return new int[] { };
            //}

            return ret;
        }

        public static double CalculateCircularity(VectorOfPoint contour)
        {
            var circle = CvInvoke.MinEnclosingCircle(contour);
            return circle.Area / CvInvoke.ContourArea(contour);
        }
    }
}