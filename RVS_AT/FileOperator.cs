using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using System.Threading.Tasks;

namespace RVS_AT
{
    class FileOperator
    {
        public async Task unpackerGZ()
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            DecompressGZ decompOperator = new DecompressGZ();
            DirectoryInfo directorySelected = new DirectoryInfo(Environment.CurrentDirectory+"/logs");
            List<string> filesNames = new List<string>();

            if(directorySelected.Exists)
            if(directorySelected.GetFileSystemInfos().Length != 0)
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                await decompOperator .Decompress(fileToDecompress);
                filesNames.Add(fileToDecompress.FullName);
            }
        }
    }
}
