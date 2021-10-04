using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace RVS_AT
{
    public partial class MainWindow : Window
    {
        Moduls.Menu menuModule = new Moduls.Menu();
        Moduls.Text textModule = new Moduls.Text();
        Moduls.Settings settingsModule = new Moduls.Settings();
        FileOperator fileOperator = new FileOperator();
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.FontFamily = new FontFamily("Bahnschrift");
            ProcessingAsync();
        }

        public async void ProcessingAsync()
        {
            loadMenu();
            await FromFtpToLocalFilesUpdate();
            await fileOperator.unpackerGZ();
        }

        //Grant access to the FileOperator object
        internal FileOperator grantAccess()
        {
            return fileOperator;
        }

        internal async static Task FromFtpToLocalFilesUpdate()
        {
            FTP ftpService = Settings.loadSettings();
            if (ftpService != null)
                await ftpService.Download();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
           this.DragMove();
        }
    }

    #region UserControlLoading
    public partial class MainWindow : Window
    {
        private void loadSettings()
        {
            gridDesktop.Children.Clear();
            gridDesktop.Children.Add(settingsModule);
            btnMainOperations.Content = "Operacje";
        }

        private void loadText()
        {
            gridDesktop.Children.Clear();
            gridDesktop.Children.Add(textModule);
            btnMainOperations.Content = "Operacje";
        }

        private void loadMenu()
        {
            gridDesktop.Children.Clear();
            gridDesktop.Children.Add(menuModule);
            btnMainOperations.Content = "AdminTools";
        }
    }
    #endregion
    #region UpperBeamButtons
    public partial class MainWindow : Window
    {
        private void btnClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void btnMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
    #endregion
    #region BtnLoadUserControls
    public partial class MainWindow : Window
    {
        private void btnOperations(object sender, RoutedEventArgs e)
        {
            if (gridDesktop.Children.Contains(textModule) && !Application.Current.Windows.OfType<PopupFiltrationText>().Any())
            {
                PopupFiltrationText popup = new PopupFiltrationText();
                popup.Show();
            }
        }

        private void btnMenu(object sender, RoutedEventArgs e)
        {
            if(!gridDesktop.Children.Contains(menuModule))
                loadMenu();
        }

        private void btnText(object sender, RoutedEventArgs e)
        {
            if (!gridDesktop.Children.Contains(textModule))
                loadText();
        }

        private void btnSettings(object sender, RoutedEventArgs e)
        {
            if (!gridDesktop.Children.Contains(settingsModule))
                loadSettings();
        }

        //private void btnFuture(object sender, RoutedEventArgs e)
        //{
        //}
    }
    #endregion
}
