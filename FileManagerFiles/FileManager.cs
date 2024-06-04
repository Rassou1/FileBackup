using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace A5_FileBackupCS.FileManagerFiles;


public class FileManager
{
    public string[] GetDirectoryFiles()
    {
        using (var folderBrowser = new FolderBrowserDialog())
        {
            folderBrowser.Description = "Select a Directory";
            var result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                DirectoryInfo directory = new DirectoryInfo(folderBrowser.SelectedPath);
                
                if (!directory.Exists)
                    return null;

                FileInfo[] files = directory.GetFiles();
                if (files.Length == 0)
                    return null;
                
                string[] fileNames = new string[files.Length];

                for (int i = 0; i < files.Length; i++)
                {
                    fileNames[i] = files[i].FullName;
                }
                return fileNames;
            }
            else
            {
                //Console.WriteLine("No directory selected.");
                return null;
            }
        }
    }

    public DateTime? GetDateModified(string filePath)
    {
        FileInfo file = new FileInfo(filePath);
        if (file.Exists)
        {
            return file.LastWriteTime;
        }
        else
        {
            return null;
        }
    }

    public static string[] GetFilesPath(List<FileData> fileDataList, bool backup)
    {
        string[] fileNames = new string[fileDataList.Count];
        for (int i = 0; i < fileDataList.Count(); i++)
        {
            fileNames[i] = backup ? fileDataList[i].BkpFullPath : fileDataList[i].BkpFullPath;
        }

        return fileNames;
    }

  }

