using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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
    }
}