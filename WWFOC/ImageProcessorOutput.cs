using System.Collections.Generic;

namespace WWFOC
{
    public class ImageProcessorOutput
    {
        public string Title { get; set; }

        public IReadOnlyList<ImageOutput> Images { get; set; }
    }
}