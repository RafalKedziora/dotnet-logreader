using FluentFTP;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RVS_AT
{
    public class Ftp
    {
        [JsonProperty]
        private string _host;
        [JsonProperty]
        private string _login;
        [JsonProperty]
        private string _password;
        [JsonProperty]
        public string PathToFiles;
        [JsonProperty]
        private int _port;
        public Ftp(string host, string login, string password, string pathToFiles, int port)
        {
            this._host = host;
            this._login = login;
            this._password = password;
            this.PathToFiles = pathToFiles;
            this._port = port;
        }
        #region Database access data
        public string Host()
        {
            return _host;
        }

        public string Login()
        {
            return _login;
        }

        public int Port()
        {
            return _port;
        }
        #endregion
        public async Task Download()
        {
            FtpClient client = new FtpClient(_host);
            client.Credentials = new NetworkCredential(_login, _password);
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