using Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AvaloniaLogReader.Helpers
{
    public static class FileReader
    {
        public static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<FileModel> FilterUnpacked(List<FileModel> files)
        {
            var filteredFiles = new List<FileModel>();
            foreach (var file in files)
            {
                if (file.Extension.Equals(".log.gz"))
                {
                    file.Extension = ".log";
                    filteredFiles.Add(file);
                }
            }
            filteredFiles.Add(files.FirstOrDefault(x => x.Name == "latest"));

            return filteredFiles;
        }
    }
}
