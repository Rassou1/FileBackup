using A5_FileBackupCS.FileManagerFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A5_FileBackupCS.Backup
{
    internal class FileBackup
    {
        List<FileData>fileDataList = new List<FileData>();
        long timeTaken = 0;
        public long TimeTaken => timeTaken;
        object lockObject = new object();

        public List<FileData> StartBackup(string[] filesToBackUp)
        {
            int taskCount = filesToBackUp.Length;
            int remainingTasks = taskCount;
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            foreach(string s in filesToBackUp)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    try
                    {
                        FileData result = BackupFile(s);
                        lock (fileDataList)
                        {
                            fileDataList.Add(result);
                        }
                    }
                    finally
                    {
                        lock (lockObject)
                        {
                            remainingTasks--;
                        }
                    }
                });
                
            }
            while (remainingTasks > 0)
            {
                Thread.Sleep(100);
            }

            stopWatch.Stop();
            timeTaken = stopWatch.ElapsedMilliseconds;

            return new List<FileData>(fileDataList);

        }

        FileData BackupFile(string sourcePath)
        {
            FileData fileData = new FileData(sourcePath);
            if(!File.Exists(sourcePath))
            {
             
                    string errorMsg = $"The file at {sourcePath} does not exist.";
                fileData.ErrorMsg = errorMsg;
                return fileData;
            }

            string backupPath = Path.Combine(fileData.PathOnly, "BACKUP", fileData.FileName);
            bool clearForBackup = CopyFiles(sourcePath, backupPath);
            if(clearForBackup)
            {
                fileData.BkpFullPath = backupPath;
            }
            else
            {
                fileData.ErrorMsg = "Failed to copy file.";
            }
            return fileData;
        }


        bool CopyFiles(string sourceFilePath, string targetFilePath)
        {
            try 
            {
                string directoryPath = Path.GetDirectoryName(targetFilePath);
                if(!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.Copy(sourceFilePath, targetFilePath, true);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
     
}
