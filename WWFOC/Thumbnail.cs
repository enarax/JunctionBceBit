using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WWFOC
{
    public partial class Thumbnail : UserControl
    {
        public Thumbnail(Image Img, string Filename)
        {
            InitializeComponent();
            pbx_image.Image = Img;
            lbl_text.Text = Filename;
            toolTip1.SetToolTip(lbl_text, Filename);
        }
    }
}
