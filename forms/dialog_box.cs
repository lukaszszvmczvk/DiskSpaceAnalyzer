using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace forms
{
    public partial class dialog_box : Form
    {
        Form1 parent;
        public dialog_box(Form1 parent)
        {
            InitializeComponent();
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                double a = Math.Round(((double)drive.AvailableFreeSpace / (double)drive.TotalSize) * 100, 2);
                double total = drive.TotalSize / 1000000000;
                double free = drive.TotalFreeSpace / 1000000000;

                ListViewItem item = new ListViewItem(new[] { drive.Name, $"{total}GB", $"{free}GB", $"{a}", $"{a}%" });
                listView1.Items.Add(item);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            this.parent = parent;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dotsButton_Click(object sender, EventArgs e)
        {
            aFolderRadio.Checked = true;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    folderTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (allLocalDrivesRadio.Checked)
            {
                parent.DrivesTreeView();
                this.Close();
            }
            else if (individualDrivesRadio.Checked)
            {
                if (!(listView1.SelectedItems.Count == 0))
                {
                    string drv = listView1.SelectedItems[0].Text;
                    parent.DriveTreeView(drv);
                }
                this.Close();
            }
            else if (aFolderRadio.Checked)
            {
                if (this.ValidateChildren() && Directory.Exists(folderTextBox.Text))
                {
                    parent.ListDirectory(folderTextBox.Text);
                    this.Close();
                }
            }

        }
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                // Ustawienia paska postępu
                string value = listView1.Items[e.ItemIndex].SubItems[e.ColumnIndex].Text;
                string s = "";
                for (int i = 0; i < 2; ++i)
                    s += value[i];
                int progress = (int)Int32.Parse(s);
                int progressBarWidth = e.SubItem.Bounds.Width - 4;
                int progressBarHeight = e.SubItem.Bounds.Height - 4;
                int progressBarX = e.SubItem.Bounds.X + 2;
                int progressBarY = e.SubItem.Bounds.Y + 2;

                // Rysowanie paska postępu
                Brush brush = new SolidBrush(Color.Blue);
                Brush brush2 = new SolidBrush(Color.LightGray);
                int fillWidth = (int)Math.Round((double)progress / 100 * progressBarWidth);
                e.Graphics.FillRectangle(brush2, progressBarX, progressBarY, progressBarWidth, progressBarHeight);
                e.Graphics.FillRectangle(brush, progressBarX, progressBarY, fillWidth, progressBarHeight);
                brush.Dispose();
                brush2.Dispose();
            }
            else
            {
                e.DrawDefault = true;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            individualDrivesRadio.Checked = true;
        }

        private void folderTextBox_Click(object sender, EventArgs e)
        {
            aFolderRadio.Checked = true;
        }

        private void folderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(folderTextBox.Text))
            {
                folderTextBox.ForeColor = Color.Red;
            }
            else
            {
                folderTextBox.ForeColor = Color.Black;
            }
        }

        private void folderTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!Directory.Exists(folderTextBox.Text))
            {
                errorProvider.SetError(folderTextBox, "Niepoprawna ścieżka!");
                e.Cancel = true;
                return;
            }
        }
    }
}
