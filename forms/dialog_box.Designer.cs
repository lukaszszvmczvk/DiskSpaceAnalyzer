namespace forms
{
    partial class dialog_box
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
            components = new System.ComponentModel.Container();
            allLocalDrivesRadio = new RadioButton();
            individualDrivesRadio = new RadioButton();
            aFolderRadio = new RadioButton();
            folderTextBox = new TextBox();
            dotsButton = new Button();
            okButton = new Button();
            cancelButton = new Button();
            listView1 = new ListView();
            columnName = new ColumnHeader();
            columnTotal = new ColumnHeader();
            columnFree = new ColumnHeader();
            columnused = new ColumnHeader();
            columnUsedBar = new ColumnHeader();
            fileSystemWatcher1 = new FileSystemWatcher();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // allLocalDrivesRadio
            // 
            allLocalDrivesRadio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            allLocalDrivesRadio.AutoSize = true;
            allLocalDrivesRadio.Location = new Point(32, 33);
            allLocalDrivesRadio.Margin = new Padding(3, 4, 3, 4);
            allLocalDrivesRadio.Name = "allLocalDrivesRadio";
            allLocalDrivesRadio.Size = new Size(132, 24);
            allLocalDrivesRadio.TabIndex = 0;
            allLocalDrivesRadio.TabStop = true;
            allLocalDrivesRadio.Text = "&All Local Drives";
            allLocalDrivesRadio.UseVisualStyleBackColor = true;
            // 
            // individualDrivesRadio
            // 
            individualDrivesRadio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            individualDrivesRadio.AutoSize = true;
            individualDrivesRadio.Location = new Point(32, 65);
            individualDrivesRadio.Margin = new Padding(3, 4, 3, 4);
            individualDrivesRadio.Name = "individualDrivesRadio";
            individualDrivesRadio.Size = new Size(140, 24);
            individualDrivesRadio.TabIndex = 1;
            individualDrivesRadio.TabStop = true;
            individualDrivesRadio.Text = "&Individual Drives";
            individualDrivesRadio.UseVisualStyleBackColor = true;
            // 
            // aFolderRadio
            // 
            aFolderRadio.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            aFolderRadio.AutoSize = true;
            aFolderRadio.Location = new Point(32, 232);
            aFolderRadio.Margin = new Padding(3, 4, 3, 4);
            aFolderRadio.Name = "aFolderRadio";
            aFolderRadio.Size = new Size(86, 24);
            aFolderRadio.TabIndex = 2;
            aFolderRadio.TabStop = true;
            aFolderRadio.Text = "A &Folder";
            aFolderRadio.UseVisualStyleBackColor = true;
            // 
            // folderTextBox
            // 
            folderTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            folderTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            folderTextBox.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            folderTextBox.Location = new Point(32, 264);
            folderTextBox.Margin = new Padding(3, 4, 3, 4);
            folderTextBox.Name = "folderTextBox";
            folderTextBox.Size = new Size(394, 27);
            folderTextBox.TabIndex = 3;
            folderTextBox.Click += folderTextBox_Click;
            folderTextBox.TextChanged += folderTextBox_TextChanged;
            folderTextBox.Validating += folderTextBox_Validating;
            // 
            // dotsButton
            // 
            dotsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dotsButton.Location = new Point(455, 264);
            dotsButton.Margin = new Padding(3, 4, 3, 4);
            dotsButton.Name = "dotsButton";
            dotsButton.Size = new Size(86, 31);
            dotsButton.TabIndex = 4;
            dotsButton.Text = "...";
            dotsButton.UseVisualStyleBackColor = true;
            dotsButton.Click += dotsButton_Click;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Location = new Point(357, 303);
            okButton.Margin = new Padding(3, 4, 3, 4);
            okButton.Name = "okButton";
            okButton.Size = new Size(86, 31);
            okButton.TabIndex = 5;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(455, 303);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(86, 31);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnName, columnTotal, columnFree, columnused, columnUsedBar });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(32, 101);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(394, 123);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.DrawSubItem += listView1_DrawSubItem;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnName
            // 
            columnName.Text = "Name";
            // 
            // columnTotal
            // 
            columnTotal.Text = "Total";
            // 
            // columnFree
            // 
            columnFree.Text = "Free";
            // 
            // columnused
            // 
            columnused.Text = "Used/Total";
            // 
            // columnUsedBar
            // 
            columnUsedBar.Text = "Used/Total";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // dialog_box
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(553, 348);
            Controls.Add(listView1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(dotsButton);
            Controls.Add(folderTextBox);
            Controls.Add(aFolderRadio);
            Controls.Add(individualDrivesRadio);
            Controls.Add(allLocalDrivesRadio);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(569, 384);
            Name = "dialog_box";
            StartPosition = FormStartPosition.CenterParent;
            Text = "dialog_box";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton allLocalDrivesRadio;
        private RadioButton individualDrivesRadio;
        private RadioButton aFolderRadio;
        private TextBox folderTextBox;
        private Button dotsButton;
        private Button okButton;
        private Button cancelButton;
        private ListView listView1;
        private ColumnHeader columnName;
        private ColumnHeader columnTotal;
        private ColumnHeader columnFree;
        private ColumnHeader columnused;
        private ColumnHeader columnUsedBar;
        private FileSystemWatcher fileSystemWatcher1;
        private ErrorProvider errorProvider;
    }
}