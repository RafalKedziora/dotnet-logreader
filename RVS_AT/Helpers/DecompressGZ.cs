using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace RVS_AT
{
    public static class DecompressGz
    {
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
