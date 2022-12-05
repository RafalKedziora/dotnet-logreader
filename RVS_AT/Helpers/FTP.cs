using FluentFTP;
using System;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RVS_AT
{
    public class Ftp : INotifyPropertyChanged
    {
        private string _host;
        private string _login;
        private string _password;
        public string _pathToFiles;
        private string _port;

        public Ftp(string host, string login, string password, string pathToFiles, string port)
        {
            (_host, _login, _password, _pathToFiles, _port) = (host, login, password, pathToFiles, port);
        }
        public void Download()
        {
            FtpClient client = new FtpClient(_host);
            client.Credentials = new NetworkCredential(_login, _password);
            try
            {
                client.Connect();
                client.DownloadDirectory(Environment.CurrentDirectory + "/logs", _pathToFiles, FtpFolderSyncMode.Update);
                client.Disconnect();
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