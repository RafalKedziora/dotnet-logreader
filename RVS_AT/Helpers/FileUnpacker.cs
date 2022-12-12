using RVS_AT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace RVS_AT
{
    public class FileUnpacker
    {
        public List<FileModel> GetFilesToUnpack()
        {
            var currentDirectory = Environment.CurrentDirectory + "/logs";
            var directoryFiles = Directory.GetFiles(currentDirectory);

            var files = new List<FileModel>();
            foreach (var filePath in directoryFiles)
            {
                var fileModel = new FileModel
                {
                    Name = Path.GetFileName(filePath),
                    Extension = Path.GetExtension(filePath)
                };

                files.Add(fileModel);
            }

            files = FilterUnpacked(files);

            return files;
        }

        public List<FileModel> FilterUnpacked(List<FileModel> files)
        { 
            foreach(var file in files)
            {
                if(file.Extension == ".log" && files.Exists(x => x.Name == file.Name && x.Extension == ".log.gz"))
                {
                    files.Remove(file);
                }
            }
            return files;
        }

        public async Task Decompress(FileInfo fileToDecompress)
        {
            await using FileStream originalFileStream = fileToDecompress.OpenRead();
            string currentFileName = fileToDecompress.FullName;
            string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

            await using FileStream decompressedFileStream = File.Create(newFileName);
            await using GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress);
            await decompressionStream.CopyToAsync(decompressedFileStream);
        }
    }
}
