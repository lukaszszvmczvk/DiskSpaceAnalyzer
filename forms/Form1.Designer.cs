namespace forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            selectMenu = new ToolStripMenuItem();
            cancelMenu = new ToolStripMenuItem();
            exitMenu = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            aboutMenu = new ToolStripMenuItem();
            tableLayoutPanel = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            selectButton = new Button();
            treeView = new TreeView();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            detailsTextBox = new TextBox();
            tabPage2 = new TabPage();
            canvas = new PictureBox();
            chartTypeBox = new ComboBox();
            chartTypeLabel = new Label();
            statusStrip1 = new StatusStrip();
            progressBar = new ToolStripProgressBar();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            menuStrip1.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu, helpMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { selectMenu, cancelMenu, exitMenu });
            fileMenu.Name = "fileMenu";
            fileMenu.ShortcutKeys = Keys.Alt | Keys.F4;
            fileMenu.Size = new Size(46, 24);
            fileMenu.Text = "File";
            // 
            // selectMenu
            // 
            selectMenu.Name = "selectMenu";
            selectMenu.ShortcutKeys = Keys.Control | Keys.S;
            selectMenu.Size = new Size(224, 26);
            selectMenu.Text = "Select";
            selectMenu.Click += SelectBox;
            // 
            // cancelMenu
            // 
            cancelMenu.Name = "cancelMenu";
            cancelMenu.ShortcutKeys = Keys.Control | Keys.T;
            cancelMenu.Size = new Size(224, 26);
            cancelMenu.Text = "Cancel";
            cancelMenu.Click += cancelMenu_Click;
            // 
            // exitMenu
            // 
            exitMenu.Name = "exitMenu";
            exitMenu.ShortcutKeys = Keys.Alt | Keys.F4;
            exitMenu.Size = new Size(224, 26);
            exitMenu.Text = "Exit";
            exitMenu.Click += exitMenu_Click;
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { aboutMenu });
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(55, 24);
            helpMenu.Text = "Help";
            // 
            // aboutMenu
            // 
            aboutMenu.Name = "aboutMenu";
            aboutMenu.Size = new Size(133, 26);
            aboutMenu.Text = "About";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(splitContainer1, 0, 0);
            tableLayoutPanel.Controls.Add(statusStrip1, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 30);
            tableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 94.78674F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.21327F));
            tableLayoutPanel.Size = new Size(914, 570);
            tableLayoutPanel.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 4);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(selectButton);
            splitContainer1.Panel1.Controls.Add(treeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl);
            splitContainer1.Size = new Size(908, 532);
            splitContainer1.SplitterDistance = 301;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // selectButton
            // 
            selectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectButton.Location = new Point(207, 4);
            selectButton.Margin = new Padding(3, 4, 3, 4);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(86, 31);
            selectButton.TabIndex = 1;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += SelectBox;
            // 
            // treeView
            // 
            treeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView.Location = new Point(3, 37);
            treeView.Margin = new Padding(3, 4, 3, 4);
            treeView.Name = "treeView";
            treeView.Size = new Size(295, 495);
            treeView.TabIndex = 0;
            treeView.BeforeExpand += treeView_BeforeExpand;
            treeView.AfterSelect += treeView_AfterSelect;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(602, 532);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(detailsTextBox);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(594, 499);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Details";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // detailsTextBox
            // 
            detailsTextBox.Dock = DockStyle.Fill;
            detailsTextBox.Location = new Point(3, 3);
            detailsTextBox.Multiline = true;
            detailsTextBox.Name = "detailsTextBox";
            detailsTextBox.ReadOnly = true;
            detailsTextBox.Size = new Size(588, 493);
            detailsTextBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(canvas);
            tabPage2.Controls.Add(chartTypeBox);
            tabPage2.Controls.Add(chartTypeLabel);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(594, 499);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Charts";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // canvas
            // 
            canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            canvas.Location = new Point(6, 51);
            canvas.Name = "canvas";
            canvas.Size = new Size(582, 442);
            canvas.TabIndex = 2;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // chartTypeBox
            // 
            chartTypeBox.FormattingEnabled = true;
            chartTypeBox.Items.AddRange(new object[] { "Bar chart", "Log bar chart", "Pie chart" });
            chartTypeBox.Location = new Point(102, 17);
            chartTypeBox.Name = "chartTypeBox";
            chartTypeBox.Size = new Size(151, 28);
            chartTypeBox.TabIndex = 1;
            chartTypeBox.SelectedValueChanged += chartTypeBox_SelectedValueChanged;
            // 
            // chartTypeLabel
            // 
            chartTypeLabel.AutoSize = true;
            chartTypeLabel.Location = new Point(16, 20);
            chartTypeLabel.Name = "chartTypeLabel";
            chartTypeLabel.Size = new Size(80, 20);
            chartTypeLabel.TabIndex = 0;
            chartTypeLabel.Text = "Chart type:";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { progressBar });
            statusStrip1.Location = new Point(0, 546);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 16);
            progressBar.Step = 1;
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(tableLayoutPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 584);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Disc Space Analyzer";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem selectMenu;
        private ToolStripMenuItem cancelMenu;
        private ToolStripMenuItem exitMenu;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem aboutMenu;
        private TableLayoutPanel tableLayoutPanel;
        private SplitContainer splitContainer1;
        private Button selectButton;
        private TreeView treeView;
        private StatusStrip statusStrip1;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox detailsTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ToolStripProgressBar progressBar;
        private Label chartTypeLabel;
        private ComboBox chartTypeBox;
        private PictureBox canvas;
    }
}