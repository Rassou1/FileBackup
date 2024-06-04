
using A5_FileBackupCS.Backup;
using A5_FileBackupCS.FileManagerFiles;
using System.ComponentModel;

namespace A5_FileBackupCS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lstSource.Items.Clear();
            lstTarget.Items.Clear();
        }

 
        private void btnStart_Click(object sender, EventArgs e)
        {
            String[] filePaths = GetFilePaths();

            if (filePaths != null)
            {
                FileBackup backup = new FileBackup();

                List<FileData> fileData = backup.StartBackup(filePaths);

                string[] backupFileNames = FileManager.GetFilesPath(fileData, true);

                lstTarget.Items.Clear();
                lstSource.Items.Clear();

                lstSource.Items.Add("");
                lstSource.Items.Add($"Time taken to back up: {backup.TimeTaken} milliseconds :)");
                //back-up code
            }
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            String[] filePaths = GetFilePaths();

            if (filePaths != null)
            {
                if(filePaths != null)
                {
                    FileBackupAsync backup = new FileBackupAsync();
                    List<FileData> list = await backup.StartBackupAsync(filePaths);

                    string[] backupFileNames = FileManager.GetFilesPath(list, true);
                    lstTarget.Items.Clear();
                    lstSource.Items.Clear();

                    lstSource.Items.Add("");
                    lstSource.Items.Add($"Time taken to back up: {backup.TimeTaken} milliseconds :)");
                }
                
            }
        }



        private string[] GetFilePaths()
        {
            FileManager fileManager = new FileManager();

            string[] filePaths = fileManager.GetDirectoryFiles();

            if (filePaths != null)
            {
                lstSource.Items.Clear();
                lstSource.Items.AddRange(filePaths);
            }

            return filePaths;
        }
    }
}

