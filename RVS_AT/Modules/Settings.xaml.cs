using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace RVS_AT.Modules
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void TextboxGotFocus(object sender, RoutedEventArgs e)
        {
            string oldOne = sender.ToString();
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextboxGotFocus;
        }

        private void SaveFtpBtn(object sender, RoutedEventArgs e)
        {
            var saveFtpConnectionInfo = new Ftp(hostTB.Text, loginTB.Text, passwordTB.passwordBox.Password.ToString(), pathToFilesTB.Text, Convert.ToInt32(portTB.Text));
            string settingsSerialized = JsonConvert.SerializeObject(saveFtpConnectionInfo);
            File.WriteAllText(@"Settings.json", settingsSerialized);
            _ = MainWindow.FromFtpToLocalFilesUpdate();
        }
    }
}
