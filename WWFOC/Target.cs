using System.Drawing;

namespace WWFOC
{
    public class Target
    {
        public Target(PointF center)
        {
            Center = center;
        }

        public PointF Center { get; }
    }
}