using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace RVS_AT.Modules
{
    public partial class Settings : UserControl
    {
        private Ftp ftpAccess = ((MainWindow)Application.Current.MainWindow).ftpService;
        public Settings()
        {
            InitializeComponent();
            hostTB.Text = ftpAccess.Host;
            loginTB.Text = ftpAccess.Login;
            pathToFilesTB.Text = ftpAccess.PathToFiles;
            portTB.Text = ftpAccess.Port;
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
            ftpAccess.Host = hostTB.Text;
            ftpAccess.Login = loginTB.Text;
            ftpAccess.SetPassword(passwordTB.passwordBox.Password.ToString());
            ftpAccess.PathToFiles = pathToFilesTB.Text;
            ftpAccess.Port = portTB.Text;
            string settingsSerialized = JsonConvert.SerializeObject(ftpAccess);
            File.WriteAllText(@"Settings.json", settingsSerialized);
            _ = ((MainWindow)Application.Current.MainWindow).FromFtpToLocalFilesUpdate();
        }

        private void SaveColorsBtn(object sender, RoutedEventArgs e)
        {
            string[] textboxes = new string[]{ gradient1.Text, gradient2.Text, gradient3.Text, backgroundColor.Text, backgroundButton.Text };

            App.Current.MainWindow.DataContext = this;
            MainWindow._uiColors.ChangeColor(textboxes);
            App.Current.MainWindow.DataContext = this;
            MainWindow._uiColors.ChangeColor(textboxes);
        }
    }
}
