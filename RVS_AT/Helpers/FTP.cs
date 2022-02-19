using FluentFTP;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RVS_AT
{
    public class Ftp : INotifyPropertyChanged
    {
        [JsonProperty]
        private string _host;
        [JsonProperty]
        private string _login;
        [JsonProperty]
        private string _password;
        [JsonProperty]
        public string _pathToFiles;
        [JsonProperty]
        private string _port;

        public Ftp(string host, string login, string password, string pathToFiles, string port)
        {
            (_host, _login, _password, _pathToFiles, _port) = (host, login, password, pathToFiles, port);
        }
        #region Database access data
        public string Host
        {
            get { return _host; }
            set { _host = value; OnPropertyChanged("Text"); }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged("Text"); }
        }

        public string Port
        {
            get { return _port; }
            set { _port = value; OnPropertyChanged("Text"); }
        }

        public string PathToFiles
        {
            get { return _pathToFiles; }
            set { _pathToFiles = value; OnPropertyChanged("Text"); }
        }
        public void SetPassword(string passwd)
        {
            this._password = passwd;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}