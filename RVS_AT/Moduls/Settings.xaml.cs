using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace RVS_AT.Moduls
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void textboxGotFocus(object sender, RoutedEventArgs e)
        {
            string oldOne = sender.ToString();
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= textboxGotFocus;
        }

        private void saveFtpBtn(object sender, RoutedEventArgs e)
        {
            var saveFtpConnectionInfo = new FTP(hostTB.Text, loginTB.Text, passwordTB.passwordBox.Password.ToString(), pathToFilesTB.Text, Convert.ToInt32(portTB.Text));
            string settingsSerialized = JsonConvert.SerializeObject(saveFtpConnectionInfo);
            File.WriteAllText(@"Settings.json", settingsSerialized);
            MainWindow.FromFtpToLocalFilesUpdate();
        }
    }
}
