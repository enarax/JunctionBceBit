using System.Drawing;

namespace WWFOC
{
    public class ImageOutput
    {
        public ImageOutput(Bitmap bitmap, string title)
        {
            Bitmap = bitmap;
            Title = title;
        }

        public Bitmap Bitmap { get; }
        
        public string Title { get; }
    }
}