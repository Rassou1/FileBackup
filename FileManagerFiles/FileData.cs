using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_FileBackupCS.FileManagerFiles;

public class FileData
{
    // Automatic properties for simplification
    public string FullPath { get; private set; }
    public string FileName { get; private set; }
    public string NameOnly { get; private set; }
    public string Extension { get; private set; }
    public string ErrorMsg { get; set; }
    public string PathOnly { get; private set; }
    public string BkpFullPath { get; set; }

    // Constructor
    // other methods

    public FileData(string fullPath)
    {
        CreateThisFromPath(fullPath);
    }

    void CreateThisFromPath(string fullPath)
    {
        try
        {
            if (!File.Exists(fullPath))
            {
                ErrorMsg = ("File Does Not Exist");
                return;
            }
            FullPath = fullPath;
            FileName = Path.GetFileName(fullPath);
            PathOnly = Path.GetDirectoryName(fullPath);

            int dotIndex = FileName.LastIndexOf('.');

            if (dotIndex == -1)
            {
                Extension = "";
                NameOnly = FileName;
            }
            else
            {
                NameOnly = FileName.Substring(0, dotIndex);
                Extension = FileName.Substring(dotIndex + 1);
            }
        }
        catch (Exception ex)
        {
            ErrorMsg = ex.Message;
        }

    }
   
}


