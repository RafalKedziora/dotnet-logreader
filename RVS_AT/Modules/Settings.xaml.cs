using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace RVS_AT.Modules
{
    public partial class Settings : UserControl
    {
        private Ftp ftpAccess = ((MainWindow)Application.Current.MainWindow).ftpService;
        private UIColors colors = ((MainWindow)Application.Current.MainWindow).uiColors;
        public Settings()
        {
            InitializeComponent();
            if (ftpAccess != null)
            {
                hostTB.Text = ftpAccess.Host;
                loginTB.Text = ftpAccess.Login;
                pathToFilesTB.Text = ftpAccess.PathToFiles;
                portTB.Text = ftpAccess.Port;
            }
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
            File.WriteAllText(@"Settings/Ftp.json", settingsSerialized);
            ((MainWindow)Application.Current.MainWindow).FromFtpToLocalFilesUpdate();
        }

        private void SaveColorsBtn(object sender, RoutedEventArgs e)
        {
            string[] textboxes = new string[]{ Gradient1.Text, Gradient2.Text, Gradient3.Text, BackgroundColor.Text, BackgroundButton.Text };

            App.Current.Windows.OfType<MainWindow>().FirstOrDefault().DataContext = this;
            App.Current.Windows.OfType<MainWindow>().FirstOrDefault().uiColors.ChangeColor(textboxes);

            string colorsSerialized = JsonConvert.SerializeObject(colors);
            File.WriteAllTextAsync(@"Settings/Colors.json", colorsSerialized);

            App.Current.Windows.OfType<MainWindow>().FirstOrDefault().RestartApp();
        }
    }
}
