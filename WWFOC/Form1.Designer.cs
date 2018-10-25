namespace WWFOC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabViewer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDebug = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Finished = new System.Windows.Forms.Button();
            this.lbl_Perc = new System.Windows.Forms.Label();
            this.lbl_OoO = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Positive = new System.Windows.Forms.Button();
            this.btn_Negativ = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbl_Filename = new System.Windows.Forms.Label();
            this.pnl_Buttons = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbx_Before = new System.Windows.Forms.PictureBox();
            this.pbx_After = new System.Windows.Forms.PictureBox();
            this.tabViewer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Buttons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Before)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_After)).BeginInit();
            this.SuspendLayout();
            // 
            // tabViewer
            // 
            this.tabViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabViewer.Controls.Add(this.tabPage1);
            this.tabViewer.Controls.Add(this.tabPage2);
            this.tabViewer.Location = new System.Drawing.Point(3, 3);
            this.tabViewer.Name = "tabViewer";
            this.tableLayoutPanel1.SetRowSpan(this.tabViewer, 4);
            this.tabViewer.SelectedIndex = 0;
            this.tabViewer.Size = new System.Drawing.Size(541, 566);
            this.tabViewer.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(533, 540);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(6, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDebug
            // 
            this.buttonDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDebug.Location = new System.Drawing.Point(305, 655);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(75, 23);
            this.buttonDebug.TabIndex = 5;
            this.buttonDebug.Text = "DEBUG";
            this.buttonDebug.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.Location = new System.Drawing.Point(1127, 18);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(35, 29);
            this.btn_close.TabIndex = 7;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.panel1.Controls.Add(this.btn_Finished);
            this.panel1.Controls.Add(this.lbl_Perc);
            this.panel1.Controls.Add(this.lbl_OoO);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 701);
            this.panel1.TabIndex = 8;
            // 
            // btn_Finished
            // 
            this.btn_Finished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Finished.Enabled = false;
            this.btn_Finished.FlatAppearance.BorderSize = 0;
            this.btn_Finished.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Finished.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Finished.ForeColor = System.Drawing.Color.White;
            this.btn_Finished.Location = new System.Drawing.Point(30, 639);
            this.btn_Finished.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Finished.Name = "btn_Finished";
            this.btn_Finished.Size = new System.Drawing.Size(166, 45);
            this.btn_Finished.TabIndex = 15;
            this.btn_Finished.Text = "Finish";
            this.btn_Finished.UseVisualStyleBackColor = true;
            this.btn_Finished.Click += new System.EventHandler(this.btn_Finished_Click);
            // 
            // lbl_Perc
            // 
            this.lbl_Perc.AutoSize = true;
            this.lbl_Perc.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Perc.ForeColor = System.Drawing.Color.White;
            this.lbl_Perc.Location = new System.Drawing.Point(9, 75);
            this.lbl_Perc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Perc.Name = "lbl_Perc";
            this.lbl_Perc.Size = new System.Drawing.Size(69, 37);
            this.lbl_Perc.TabIndex = 2;
            this.lbl_Perc.Text = "30%";
            this.lbl_Perc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_OoO
            // 
            this.lbl_OoO.AutoSize = true;
            this.lbl_OoO.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_OoO.ForeColor = System.Drawing.Color.White;
            this.lbl_OoO.Location = new System.Drawing.Point(144, 75);
            this.lbl_OoO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_OoO.Name = "lbl_OoO";
            this.lbl_OoO.Size = new System.Drawing.Size(58, 37);
            this.lbl_OoO.TabIndex = 1;
            this.lbl_OoO.Text = "0/0";
            this.lbl_OoO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(9, 115);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 479);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.listBox1_ControlAdded);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(62)))), ((int)(((byte)(114)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(250, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(914, 17);
            this.panel2.TabIndex = 9;
            // 
            // btn_Positive
            // 
            this.btn_Positive.FlatAppearance.BorderSize = 0;
            this.btn_Positive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Positive.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Positive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.btn_Positive.Image = ((System.Drawing.Image)(resources.GetObject("btn_Positive.Image")));
            this.btn_Positive.Location = new System.Drawing.Point(102, 7);
            this.btn_Positive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Positive.Name = "btn_Positive";
            this.btn_Positive.Size = new System.Drawing.Size(41, 45);
            this.btn_Positive.TabIndex = 10;
            this.btn_Positive.UseVisualStyleBackColor = true;
            this.btn_Positive.Click += new System.EventHandler(this.btn_Positive_Click);
            // 
            // btn_Negativ
            // 
            this.btn_Negativ.FlatAppearance.BorderSize = 0;
            this.btn_Negativ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Negativ.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Negativ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.btn_Negativ.Image = ((System.Drawing.Image)(resources.GetObject("btn_Negativ.Image")));
            this.btn_Negativ.Location = new System.Drawing.Point(8, 6);
            this.btn_Negativ.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Negativ.Name = "btn_Negativ";
            this.btn_Negativ.Size = new System.Drawing.Size(41, 45);
            this.btn_Negativ.TabIndex = 11;
            this.btn_Negativ.UseVisualStyleBackColor = true;
            this.btn_Negativ.Click += new System.EventHandler(this.btn_Negativ_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1088, 18);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 29);
            this.button3.TabIndex = 12;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbl_Filename
            // 
            this.lbl_Filename.AutoSize = true;
            this.lbl_Filename.Font = new System.Drawing.Font("Segoe UI Emoji", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Filename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.lbl_Filename.Location = new System.Drawing.Point(254, 20);
            this.lbl_Filename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Filename.Name = "lbl_Filename";
            this.lbl_Filename.Size = new System.Drawing.Size(133, 26);
            this.lbl_Filename.TabIndex = 3;
            this.lbl_Filename.Text = "_filename.dcm";
            // 
            // pnl_Buttons
            // 
            this.pnl_Buttons.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnl_Buttons.Controls.Add(this.btn_Negativ);
            this.pnl_Buttons.Controls.Add(this.btn_Positive);
            this.pnl_Buttons.Location = new System.Drawing.Point(436, 641);
            this.pnl_Buttons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnl_Buttons.Name = "pnl_Buttons";
            this.pnl_Buttons.Size = new System.Drawing.Size(147, 59);
            this.pnl_Buttons.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1049, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 29);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.61998F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.38002F));
            this.tableLayoutPanel1.Controls.Add(this.pbx_After, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbx_Before, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabViewer, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(259, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 572);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(549, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 28);
            this.label1.TabIndex = 16;
            this.label1.Text = "Image before:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(549, 285);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Image after:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbx_Before
            // 
            this.pbx_Before.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbx_Before.Location = new System.Drawing.Point(550, 31);
            this.pbx_Before.Name = "pbx_Before";
            this.pbx_Before.Size = new System.Drawing.Size(350, 251);
            this.pbx_Before.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_Before.TabIndex = 18;
            this.pbx_Before.TabStop = false;
            // 
            // pbx_After
            // 
            this.pbx_After.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbx_After.Location = new System.Drawing.Point(550, 317);
            this.pbx_After.Name = "pbx_After";
            this.pbx_After.Size = new System.Drawing.Size(350, 252);
            this.pbx_After.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_After.TabIndex = 19;
            this.pbx_After.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 701);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnl_Buttons);
            this.Controls.Add(this.lbl_Filename);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.buttonDebug);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabViewer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Buttons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Before)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_After)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabViewer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonDebug;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Positive;
        private System.Windows.Forms.Button btn_Negativ;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbl_Perc;
        private System.Windows.Forms.Label lbl_OoO;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbl_Filename;
        private System.Windows.Forms.Panel pnl_Buttons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Finished;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbx_After;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbx_Before;
    }
}

