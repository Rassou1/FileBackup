using A5_FileBackupCS.FileManagerFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_FileBackupCS.Backup
{
    internal class FileBackupAsync
    {
        List<FileData> fileDataList = new List<FileData>();
        long timeTaken = 0;
        public long TimeTaken => timeTaken;

        public async Task<List<FileData>> StartBackupAsync(string[] filesToBackUp)
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            List<Task<FileData>> tasks = new List<Task<FileData>>();

            foreach(string filePath in filesToBackUp)
            {
                tasks.Add(BackupFileAsync(filePath));
            }

            var results = await Task.WhenAll(tasks);
            lock (fileDataList)
            {
                fileDataList.AddRange(results);
            }
            stopWatch.Stop();
            timeTaken = stopWatch.ElapsedMilliseconds;
            return fileDataList;
        }

        public async Task<FileData> BackupFileAsync(string sourcePath)
        {
            FileData fileData = new FileData(sourcePath);
            if(!File.Exists(sourcePath))
            {
                string errorMsg = "Following source file does not exist: " +  sourcePath;
                fileData.ErrorMsg= errorMsg;
                return fileData;
            }

            string backupPath = Path.Combine(fileData.PathOnly, "BACKUP ASYNC", fileData.FileName);
            try
            {
                await CopyFilesAsync(sourcePath, backupPath);
                fileData.BkpFullPath = backupPath;  
            }
            catch(Exception ex)
            {
                fileData.ErrorMsg = "Failed to copy file. For more details: " + ex.Message;
            }
            return fileData;

        }

        public async Task CopyFilesAsync(string sourceFilePath, string targetFilePath)
        {
            string directoryPath = Path.GetDirectoryName(targetFilePath);
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            File.Copy(sourceFilePath, targetFilePath, true);
        }
    }
}
