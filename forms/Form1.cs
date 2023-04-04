using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace forms
{
    public partial class Form1 : Form
    {
        Dictionary<int, double> data = new Dictionary<int, double>();
        string path;
        public Form1()
        {
            InitializeComponent();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DrivesTreeView();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void SelectBox(object sender, EventArgs e)
        {
            dialog_box dialogBox = new dialog_box(this);
            dialogBox.ShowDialog();
        }
        private void selectButton_Click(object sender, EventArgs e)
        {
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }
        public void DriveTreeView(string drive)
        {
            treeView.Nodes.Clear();
            DriveInfo di = new DriveInfo(drive);
            int driveImage;

            switch (di.DriveType)    //set the drive's icon
            {
                case DriveType.CDRom:
                    driveImage = 3;
                    break;
                case DriveType.Network:
                    driveImage = 6;
                    break;
                case DriveType.NoRootDirectory:
                    driveImage = 8;
                    break;
                case DriveType.Unknown:
                    driveImage = 8;
                    break;
                default:
                    driveImage = 2;
                    break;
            }

            TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
            node.Tag = drive;

            if (di.IsReady == true)
                node.Nodes.Add("...");

            treeView.Nodes.Add(node);
        }
        public void DrivesTreeView()
        {
            treeView.Nodes.Clear();
            //get a list of the drives
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                //ListDirectory(drive);
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    //set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                treeView.Nodes.Add(node);
            }
        }
        public void ListDirectory(string path)
        {
            treeView.Nodes.Clear();
            DirectoryInfo di = new DirectoryInfo(path);
            TreeNode node = new TreeNode(di.Name, 0, 1);
            node.Tag = path;
            //if the directory has sub directories add the place holder
            if (di.GetDirectories().Count() > 0)
                node.Nodes.Add(null, "...", 0, 0);
            treeView.Nodes.Add(node);

        }

        //https://stackoverflow.com/questions/35159549/how-to-display-all-files-under-folders-in-treeview
        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    //add files of rootdirectory
                    DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
                    if (rootDir.GetFiles().Length > 3)
                    {
                        TreeNode groupNode = new TreeNode("<File>");
                        groupNode.Tag = "<File>";
                        e.Node.Nodes.Add(groupNode);
                        foreach (var file in rootDir.GetFiles())
                        {
                            TreeNode n = new TreeNode(file.Name, 13, 13);
                            n.Tag = file.FullName;
                            groupNode.Nodes.Add(n);
                        }
                    }
                    else
                    {
                        foreach (var file in rootDir.GetFiles())
                        {
                            TreeNode n = new TreeNode(file.Name, 13, 13);
                            n.Tag = file.FullName;
                            e.Node.Nodes.Add(n);
                        }
                    }

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                            if (di.GetFiles().Length > 3)
                            {
                                TreeNode groupNode = new TreeNode("<File>");
                                node.Nodes.Add(groupNode);
                                foreach (var file in di.GetFiles())
                                {
                                    TreeNode n = new TreeNode(file.Name, 13, 13);
                                    n.Tag = file.FullName;
                                    groupNode.Nodes.Add(n);
                                }
                            }
                            else
                            {
                                foreach (var file in di.GetFiles())
                                {
                                    TreeNode n = new TreeNode(file.Name, 13, 13);
                                    n.Tag = file.FullName;
                                    node.Nodes.Add(n);
                                }
                            }

                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null)
            {
                if (backgroundWorker.IsBusy)
                    backgroundWorker.CancelAsync();

                while (backgroundWorker.IsBusy)
                    Application.DoEvents();
                path = (string)selectedNode.Tag;
                if (path == "<File>")
                {
                    detailsTextBox.Clear();
                }
                else
                {
                    backgroundWorker.RunWorkerAsync();
                    DateTime lastModified = Directory.GetLastWriteTime(path);
                    detailsTextBox.Clear();
                    detailsTextBox.AppendText($"Full path:\t{path}\r\n");
                    detailsTextBox.AppendText($"Last change:\t{lastModified}\r\n");
                }
            }
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (path == "<File>")
                return;
            FileAttributes attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                try
                {
                    long totalSize = 0;
                    long totalFiles = 0;
                    long totalFolders = 0;
                    long n = Directory.GetDirectories(path).Length;

                    // Wywo³anie metody CountFilesAndFolders, która zwraca liczbê plików i folderów oraz ich rozmiar
                    CountFilesAndFolders(path, ref totalSize, ref totalFiles, ref totalFolders, n, e, 0);

                    // Przekazanie wyników do obiektu e.Result
                    e.Result = new long[] { totalFiles, totalFolders, totalSize };
                }
                catch
                {
                    path = "Access denied!";
                }
            }
            else
            {
                FileInfo fileInfo = new FileInfo(path);
                e.Result = new long[] { fileInfo.Length };
            }

        }

        private void CountFilesAndFolders(string path, ref long totalSize, ref long totalFiles, ref long totalFolders, long n, DoWorkEventArgs e, int level)
        {
            int z = 0;
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    // Rekurencyjne wywo³anie metody dla ka¿dego podfolderu
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    CountFilesAndFolders(dir, ref totalSize, ref totalFiles, ref totalFolders, n, e, level + 1);
                    totalFolders++;
                    ++z;
                    if (level == 0)
                    {
                        int progress = (int)((float)z / (float)n) * 100;
                        this.Invoke((MethodInvoker)delegate { backgroundWorker.ReportProgress((int)(progress)); });
                        Thread.Sleep(100);
                    }
                }

                foreach (string file in Directory.GetFiles(path))
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    // Zliczenie rozmiaru ka¿dego pliku i zwiêkszenie licznika plików
                    FileInfo fileInfo = new FileInfo(file);
                    totalSize += fileInfo.Length;
                    totalFiles++;
                }
            }
            catch (Exception ex)
            {
                // Obs³uga wyj¹tków
                //Console.WriteLine(ex.Message);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Wyœwietlenie wyników
            if (!e.Cancelled)
            {
                if (path == "Access denied!")
                {
                    detailsTextBox.Clear();
                    detailsTextBox.Text = path;
                    return;
                }
                if (path == "<File>")
                {
                    detailsTextBox.Clear();
                    return;
                }
                FileAttributes attr = File.GetAttributes(path);
                detailsTextBox.Clear();
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    long[] results = (long[])e.Result;
                    DateTime lastModified = Directory.GetLastWriteTime(path);
                    double size = Math.Round((double)results[2] / (double)1000000, 1);
                    detailsTextBox.AppendText($"Full path:\t{path}\r\n");
                    detailsTextBox.AppendText($"Size:\t{size} MB\r\n");
                    detailsTextBox.AppendText($"Items:\t{results[0] + results[1]}\r\n");
                    detailsTextBox.AppendText($"Files:\t{results[0]}\r\n");
                    detailsTextBox.AppendText($"Subdirs:\t{results[1]}\r\n");
                    detailsTextBox.AppendText($"Last change:\t{lastModified}\r\n");
                }
                else
                {
                    //int size = (int)e.Result;
                    DateTime lastModified = File.GetLastWriteTime(path);
                    long[] results = (long[])e.Result;
                    double size = Math.Round((double)results[0] / (double)1000000, 1);
                    detailsTextBox.AppendText($"Full path:\t{path}\r\n");
                    detailsTextBox.AppendText($"Size:\t{size} MB\r\n");
                    detailsTextBox.AppendText($"Last change:\t{lastModified}\r\n");
                }
            }
        }
        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Aktualizacja paska postêpu w interfejsie u¿ytkownika
            progressBar.Value = e.ProgressPercentage;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}