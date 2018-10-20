using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WWFOC
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "DICOM (*.dcm)|*.dcm";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_Path.Text = ofd.FileName;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] Path = txt_Path.Text.Split('\\');
            string FilePath ="";
            for (int i = 0; i < Path.Count()-1; i++)
            {
                 FilePath += Path[i] +"\\";
            }
          

            Form1 frm = new Form1(FilePath);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            

        }
    }
}
