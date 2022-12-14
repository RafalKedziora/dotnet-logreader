using RVS_AT.Helpers;
using RVS_AT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

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
                    Name = Path.GetFileNameWithoutExtension(filePath),
                    Extension = Path.GetExtension(filePath)
                };
                fileModel.LogDate = DateOperator.DateParser(fileModel.Name);


                files.Add(fileModel);
            }

            files = FileReader.FilterUnpacked(files);

            return files;
        }

        public async Task Decompress(FileInfo fileToDecompress)
        {
            if (fileToDecompress.Extension == ".gz")
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
}
