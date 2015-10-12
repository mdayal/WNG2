using System;

namespace CT.Utility.Interfaces
{
    public interface IFileDownloadService
    {
        void DownloadFile(Uri address, string fileName);
        bool FileIsValid(string extention, string filePath);
    }
}