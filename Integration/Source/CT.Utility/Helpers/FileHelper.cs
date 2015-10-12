using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CT.Utility.Helpers
{
    public class FileHelper
    {
        public static IList<string> GetFiles(string directory, string[] fileTypes)
        {
            var dir = new DirectoryInfo(directory);
            return dir.GetFiles("*.*").Where(f => fileTypes.Contains(f.Extension.ToLower())).Select(f => f.Name).ToList();
        }

        public static string GetFileApplicationPhysicalPath(string fileName)
        {
            return Path.IsPathRooted(fileName)
                       ? fileName
                       : string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory,
                                       fileName.StartsWith("\\") ? fileName.TrimStart('\\') : fileName);
        }

        public static string CheckAndCreateFolder(string folderPath)
        {
            var filePhysicalPath = GetFileApplicationPhysicalPath(folderPath);

            if (!Directory.Exists(filePhysicalPath))
                Directory.CreateDirectory(filePhysicalPath);
            return filePhysicalPath;
        }

        public static string FormatFolder(string folderPath)
        {
            return folderPath.EndsWith("\\")
                                              ? folderPath
                                              : folderPath + "\\";
        }
    }
}
