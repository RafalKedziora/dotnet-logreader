using FluentFTP;
using RVS_AT.Models;
using RVS_AT.Stores;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RVS_AT
{
    public class FtpDownloader
    {
        private readonly ContentStore _contentStore;
        public FtpDownloader(ContentStore contentStore)
        {
            _contentStore = contentStore;
        }

        public async Task<List<FileModel>> GetListingAsync()
        {
            var token = new CancellationToken();
            var listOfFiles = new List<FileModel>();
            using (var conn = new AsyncFtpClient(
                _contentStore._ftpCredentials.Host,
                _contentStore._ftpCredentials.Login,
                _contentStore._ftpCredentials.Password,
                _contentStore._ftpCredentials.Port))
            {
                await conn.Connect(token);
                var idSetter = 0;
                foreach (var item in await conn.GetListing(_contentStore._ftpCredentials.PathToFiles, FtpListOption.Recursive, token))
                {
                    if (item.Type == FtpObjectType.File)
                    {
                        idSetter++;

                        var itemFullName = item.FullName.Split('.', 2);
                        listOfFiles.Add(new FileModel
                        {
                            Id = idSetter,
                            Name = itemFullName[0],
                            Extension = itemFullName[1],
                        });
                        Console.WriteLine("File!  " + item.FullName);
                    }
                }
            }
            return listOfFiles;
        }

        public void DownloadFile(FileModel file)
        {
            FtpClient client = new FtpClient(
            _contentStore._ftpCredentials.Host,
            _contentStore._ftpCredentials.Login,
            _contentStore._ftpCredentials.Password,
            _contentStore._ftpCredentials.Port);

            using (client)
            {
                client.Connect();
                client.DownloadFile($"{Environment.CurrentDirectory}/logs/{file.Name}.{file.Extension}", $"{_contentStore._ftpCredentials.PathToFiles}/{file.Name}.{file.Extension}", FtpLocalExists.Skip, FtpVerify.Retry);
                client.Disconnect();
            }
        }
    }
}