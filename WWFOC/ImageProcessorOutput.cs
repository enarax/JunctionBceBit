using System.Collections.Generic;
using System.IO;

namespace WWFOC
{
    public class ImageProcessorOutput
    {
        public FileInfo SourceFile { get; set; }
        
        public string Title { get; set; }

        public IReadOnlyList<ImageOutput> Images { get; set; }
    }
}