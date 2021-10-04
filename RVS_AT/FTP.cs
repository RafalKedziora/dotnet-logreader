using FluentFTP;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RVS_AT
{
    public class FTP
    {
        [JsonProperty]
        private string host;
        [JsonProperty]
        private string login;
        [JsonProperty]
        private string password;
        [JsonProperty]
        public string pathToFiles;
        [JsonProperty]
        private int port;
        public FTP(string host, string login, string password, string pathToFiles, int port)
        {
            this.host = host;
            this.login = login;
            this.password = password;
            this.pathToFiles = pathToFiles;
            this.port = port;
        }
        #region Database access data
        public string Host()
        {
            return host;
        }

        public string Login()
        {
            return login;
        }

        public string Password()
        {
            return password;
        }

        public int Port()
        {
            return port;
        }
        #endregion
        public async Task Download()
        {
            FtpClient client = new FtpClient(host);
            client.Credentials = new NetworkCredential(login, password);
            try
            {
                await client.ConnectAsync();
                await client.DownloadDirectoryAsync(Environment.CurrentDirectory + "/logs", "/logs", FtpFolderSyncMode.Update);
                await client.DisconnectAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"FTP Connection Exception: {e}");
            }
        }
    }
}