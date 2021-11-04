using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace RVS_AT
{
    public static class DecompressGz
    {
        #region kompresja
        //public void Compress(FileInfo fileToCompress)
        //{
        //    using (FileStream originalFileStream = fileToCompress.OpenRead())
        //    {
        //        if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
        //        {
        //            using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
        //            {
        //                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
        //                {
        //                    originalFileStream.CopyTo(compressionStream);
        //                    Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
        //                        fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion

        public static async Task Decompress(this FileInfo fileToDecompress)
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
