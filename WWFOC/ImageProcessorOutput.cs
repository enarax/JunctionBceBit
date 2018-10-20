using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WWFOC
{
    public class ImageProcessorOutput
    {
        public FileInfo SourceFile { get; set; }
        
        public string Title { get; set; }

        public IReadOnlyList<ImageOutput> Images { get; set; }

        public IReadOnlyList<Target> Targets { get; set; }

        public bool Positive => Targets.Any();
    }
}