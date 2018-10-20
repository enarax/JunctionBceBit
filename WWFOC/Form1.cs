using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dicom;
using Dicom.Imaging;

namespace WWFOC
{
    public partial class Form1 : Form
    {

        public string SourcePath { get; } //= @"C:\Users\Benke Sándor\Documents\Junction\Dataset\386801";
        public string SourceFileMask = "MR.*";


        public int DetectionParam1 { get; set; } = 300;
        public int DetectionParam2 { get; set; } = 100;
        public int DetectionParam3 { get; set; } = 0;

        public int SelectedIndex { get; set; }
        private readonly List<ImageProcessorOutput> _output = new List<ImageProcessorOutput>(); // protected by lock(_output)
        
        
        public Form1(string Path)
        {
            InitializeComponent();
            PnlButonsAlign();
            buttonDebug.Hide();
            lbl_Filename.Hide();
            SourcePath = Path;
           
            Load += OnLoad;
            
            this.MouseWheel += OnMouseWheel;
            buttonDebug.Click += ButtonDebugOnClick;
        }

        private async void ButtonDebugOnClick(object sender, EventArgs e)
        {
            lock (_output)
            {
                if (_output.Count <= SelectedIndex) return;
            }

            ImageProcessorOutput output = _output[SelectedIndex];
            DicomFile sourceFile = await DicomFile.OpenAsync(output.SourceFile.FullName);
            using (Bitmap original = new DicomImage(sourceFile.Dataset).RenderImage().AsClonedBitmap())
            {
                ImageProcessor ip = new ImageProcessor(original, debug: true);
                ip.Process();
            }
            
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            lock (_output)
            {
                SelectedIndex = Math.Min(Math.Max(SelectedIndex + Math.Sign(e.Delta), 0), _output.Count);
            }
            for (int i = 0; i < listBox1.Items.Count; i++) //hiba, amikor a legaljára görgetünk
            {
                if (listBox1.Items[i].ToString()==_output[SelectedIndex].Title)
                {
                    listBox1.SelectedIndex = i;
                    tabViewer.SelectedTab.BackColor = Color.FromArgb(114, 25, 40);
                }
                else
                {
                    tabViewer.SelectedTab.BackColor = Color.White;
                }
            }

            RefreshView();
        }
      
        public void RefreshView()
        {
            Invoke((MethodInvoker) delegate
            {
                lock (_output)
                {
                    if (_output.Count > SelectedIndex)
                    {
                        var selectedResult = _output[SelectedIndex];
                        this.Text = selectedResult.Title;
                        for (int i = 0; i < selectedResult.Images.Count; i++)
                        {
                            var currentImage = selectedResult.Images[i];
                            if (tabViewer.TabCount <= i)
                            {
                                tabViewer.TabPages.Add(new TabPage(currentImage.Title));
                            }
                            else
                            {
                                tabViewer.TabPages[i].Text = currentImage.Title;
                            }

                            if (tabViewer.TabPages[i].Controls.Count < 1)
                            {
                                tabViewer.TabPages[i].Controls.Add(new PictureBox()
                                {
                                    Dock = DockStyle.Fill, 
                                    SizeMode = PictureBoxSizeMode.Zoom
                                });
                            }

                            ((PictureBox) tabViewer.TabPages[i].Controls[0]).Image =
                                currentImage.Bitmap.Clone(new RectangleF(PointF.Empty, currentImage.Bitmap.Size),
                                    PixelFormat.Format32bppRgb);
                        }
                    }
                }
            });
            lbl_Filename.Text = _output[SelectedIndex].Title;
            lbl_Filename.Show();
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            await UpdateImageAsync();
        }

        private async Task UpdateImageAsync()
        {

            var sourceDir = new DirectoryInfo(SourcePath);
            IEnumerable<Task<ImageProcessorOutput>> resultTasks = sourceDir.EnumerateFiles(SourceFileMask)
                .OrderBy(f =>
                {
                    string lastPart = Path.GetFileNameWithoutExtension(f.Name).Split(' ').Last();
                    Int32.TryParse(lastPart, out int index);
                    return index;
                })
                .Select(async file =>
                {
                    return await Task.Run(async () =>
                    {
                        DicomFile sourceFile = await DicomFile.OpenAsync(file.FullName);
                        using (Bitmap original = new DicomImage(sourceFile.Dataset).RenderImage().AsClonedBitmap())
                        {
                            ImageProcessor ip = new ImageProcessor(original);
                            var result = ip.Process();
                            result.Title = file.Name;
                            result.SourceFile = file;
                            return result;
                        }
                    });

                }).ToList();
            int Total = 0;
            int Pos = 0;
            foreach (var resultTask in resultTasks)
            {
                var result = await resultTask;
                var needRefresh = false;
                lock (_output)
                {
                    int resultIndex = _output.Count;
                    _output.Add(result);
                    Total = _output.Count;
                    if (result.Positive && (resultIndex == 0 || result.SignificantlyDifferentFrom(_output[resultIndex-1])))
                    {

                        string title = result.SourceFile.Name;
                        listBox1.Items.Add(title);
                        Pos = listBox1.Items.Count;                   
                    }
                    lbl_OoO.Text = $"{Pos}/{Total}";
                    
                    if (resultIndex == SelectedIndex)
                    {
                        needRefresh = true;
                    }
                }
                if (needRefresh)
                {
                    RefreshView();
                }
            }

        }
        

        //Eseménykiszolgálók

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void listBox1_ControlAdded(object sender, ControlEventArgs e)
        {
            lbl_Perc.Text = ((listBox1.Items.Count / _output.Count) * 100).ToString() + " %";
        }

        private void btn_Positive_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int KivIndex = 0;
            lock (_output)
            {
               
                foreach (var image in _output)
                {
                    if (image.Title == listBox1.SelectedItem.ToString())
                    {
                        SelectedIndex = KivIndex;
                        
                        lbl_Filename.Text = listBox1.SelectedItem.ToString();
                    }
                    else
                    {
                        KivIndex++;
                    }
                }
                RefreshView();
            }
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PnlButonsAlign();
        }

        private void PnlButonsAlign()
        {
            int MainWidth = this.Width - panel1.Width;
            pnl_Buttons.Left = MainWidth / 2 - pnl_Buttons.Width / 2;
        }
    }
}