using AvaloniaLogReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace AvaloniaLogReader
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
                    Id = files.Count + 1,
                    Name = Path.GetFileNameWithoutExtension(filePath).Split('.')[0],
                    Extension = Path.GetExtension(filePath)
                };

                fileModel.Extension = fileModel.Extension == ".gz" ? ".log.gz" : ".log";

                fileModel.LogDate = DateOperator.DateParser(fileModel.Name.Split('.')[0]);

                files.Add(fileModel);
            }

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
