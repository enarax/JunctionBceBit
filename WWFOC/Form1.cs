﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
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
        public List<ImageOutput> AllImages = new List<ImageOutput>();

        public int DetectionParam1 { get; set; } = 300;
        public int DetectionParam2 { get; set; } = 100;
        public int DetectionParam3 { get; set; } = 0;

        public int SelectedIndex { get; set; }
        private readonly IList<ImageProcessorOutput> _output = new BindingList<ImageProcessorOutput>(); // protected by lock(_output)

        #region Move

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        #endregion
        
        public Form1(string Path)
        {
            InitializeComponent();
            PnlButtonsAlign();
            buttonDebug.Hide();
            lbl_Filename.Hide();
            tabViewer.Hide();
            SourcePath = Path;

            listBox1.DataSource = _output;
            listBox1.DisplayMember = "Title";
            lbl_Perc.Hide();
            lbl_OoO.Text = "Loading...";
            label1.Hide();
            label2.Hide();
            Load += OnLoad;
            
            this.MouseWheel += OnMouseWheel;
            this.MouseDown += OnMouseDown;
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
        
        
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            lock (_output)
            {
                SelectedIndex = Math.Min(Math.Max(SelectedIndex + Math.Sign(e.Delta), 0), _output.Count - 1);
            }

            listBox1.SelectedIndex = SelectedIndex;

            RefreshView();
        }
      
        public void RefreshView()
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
                        for (int j = 0; j < AllImages.Count(); j++)
                        {
                            if (AllImages[j].Title==selectedResult.Title)
                            {
                                try
                                {
                                    var prevImage = AllImages[j-1];
                                    pbx_Before.Image = prevImage.Bitmap;
                                }
                                catch (Exception) { pbx_Before.Image = null; }//Checks if Image is first in the List 

                                try
                                {
                                    var nextImage = AllImages[j + 1];
                                    pbx_After.Image = nextImage.Bitmap;
                                }
                                catch (Exception) { pbx_After.Image = null; } //Checks if Image is last in the List

                            }
                        }
                        
                        
                        

                        if (tabViewer.TabCount <= i)
                        {
                            tabViewer.TabPages.Add(new TabPage(currentImage.Title));
                            tabViewer.SelectedIndex = i;
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
                            currentImage.Bitmap;

                        
                    }
                    
                    lbl_Filename.Text = _output[SelectedIndex].Title;
                    lbl_Filename.Show();
                    tabViewer.Show();
                    label1.Show();
                    label2.Show();
                   
                }
            }
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            await UpdateImageAsync();
        }

        private async Task UpdateImageAsync()
        {
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
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
                        using (IImage iimage = new DicomImage(sourceFile.Dataset).RenderImage())
                        {
                            Bitmap original = iimage.AsClonedBitmap();
                            ImageProcessor ip = new ImageProcessor(original);
                            var result = ip.Process();

                            result.SourceFile = file;
                            ImageOutput io = new ImageOutput(result.Images[1].Bitmap, result.Title);
                            AllImages.Add(io); //Adding all images to List 
                            return result;
                        }
                    });

                }).ToList();

            foreach (var resultTask in resultTasks)
            {
                var result = await resultTask;
                var needRefresh = false;
                lock (_output)
                {
                    int resultIndex = _output.Count;
                    if (result.Positive && (resultIndex == 0 || result.SignificantlyDifferentFrom(_output[resultIndex-1])))
                    {
                        _output.Add(result);
                    }
                    UpdateStatLabels();
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
        
        

        private void UpdateStatLabels()
        {
            lock (_output)
            {
                int totalCount = _output.Count;
                int checkedCount = _output.Count(o => o.UserDecision != null);
                lbl_OoO.Text = $@"{checkedCount}/{totalCount}";

                
                if (totalCount>0)
                {
                    lbl_Perc.Text = Math.Round((checkedCount / (double)totalCount) * 100) + " %";
                    lbl_Perc.Show();
                    if (checkedCount==totalCount)
                    {
                        btn_Finished.Enabled = true;
                    }
                }
                
                
            }
        }

        // Event handlers

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void listBox1_ControlAdded(object sender, ControlEventArgs e)
        {
            UpdateStatLabels();
        }

        private void btn_Positive_Click(object sender, EventArgs e)
        {
            var x = (ImageProcessorOutput)listBox1.SelectedItem;
            x.UserDecision = true;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                var Next = (ImageProcessorOutput)listBox1.Items[i];
                if (Next.UserDecision == null)
                {
                    listBox1.SelectedItem=listBox1.Items[i];
                    break;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                SelectedIndex = listBox1.SelectedIndex;
                RefreshView();
            }
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PnlButtonsAlign();
        }

        private void PnlButtonsAlign()
        {
            //pnl_Buttons.Left = (tabViewer.Width / 2) - (pnl_Buttons.Width/2);

            pnl_Buttons.Left = ((this.Width+panel1.Width) / 2) - (pnl_Buttons.Width / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Negativ_Click(object sender, EventArgs e)
        {
            var x = (ImageProcessorOutput)listBox1.SelectedItem;
            x.UserDecision = false;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                var Next = (ImageProcessorOutput)listBox1.Items[i];
                if (Next.UserDecision == null)
                {
                    listBox1.SelectedItem = listBox1.Items[i];
                    break;
                }
            }
        }

        private void btn_Finished_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}