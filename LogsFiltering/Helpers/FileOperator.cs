using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RVS_AT
{
    class FileOperator
    {
        public async void UnpackerGz()
        {
            List<string> fileNames = new List<string>();
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.gz", SearchOption.AllDirectories);
            
            foreach (var fileToDecompress in files)
            {
                await new FileInfo(fileToDecompress).Decompress();
                fileNames.Add(fileToDecompress);
            }
        }
    }
}
