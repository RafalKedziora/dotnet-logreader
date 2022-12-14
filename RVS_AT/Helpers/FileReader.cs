using RVS_AT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.Helpers
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
                if (file.Extension == ".log" && files.Exists(x => x.Name == file.Name + file.Extension && x.Extension == ".gz"))
                {
                    filteredFiles.Add(file);
                }
            }

            filteredFiles.Add(files.FirstOrDefault(x => x.Name == "latest"));
            
            return filteredFiles;
        }
    }
}
