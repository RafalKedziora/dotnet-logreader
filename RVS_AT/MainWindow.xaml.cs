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
        readonly Modules.Menu _menuModule = new();
        readonly Modules.Text _textModule = new();
        readonly Modules.Settings _settingsModule = new();
        readonly FileOperator _fileOperator = new();
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.FontFamily = new FontFamily("Bahnschrift");
            ProcessingAsync();
        }

        public void ProcessingAsync()
        {
            LoadMenu();
            Task ftpFiles = FromFtpToLocalFilesUpdate();
            Task unpackedFiles = _fileOperator.UnpackerGz();
        }

        //Grant access to the FileOperator object
        internal FileOperator GrantAccess()
        {
            return _fileOperator;
        }

        internal static async Task FromFtpToLocalFilesUpdate()
        {
            Ftp ftpService = Settings.LoadSettings();
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
        private void LoadSettings()
        {
            gridDesktop.Children.Clear();
            gridDesktop.Children.Add(_settingsModule);
            btnMainOperations.Content = "Operacje";
        }

        private void LoadText()
        {
            gridDesktop.Children.Clear();
            gridDesktop.Children.Add(_textModule);
            btnMainOperations.Content = "Operacje";
        }

        private void LoadMenu()
        {
            gridDesktop.Children.Clear();
            gridDesktop.Children.Add(_menuModule);
            btnMainOperations.Content = "AdminTools";
        }
    }
    #endregion
    #region UpperBeamButtons
    public partial class MainWindow : Window
    {
        private void BtnClose(object sender, RoutedEventArgs e) 
            => Application.Current.Shutdown();

        private void BtnMaximize(object sender, RoutedEventArgs e) 
            => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        private void BtnMinimize(object sender, RoutedEventArgs e) 
            => WindowState = WindowState.Minimized;
        }
    #endregion
    #region BtnLoadUserControls
    public partial class MainWindow : Window
    {
        private void BtnOperations(object sender, RoutedEventArgs e)
        {
            if (gridDesktop.Children.Contains(_textModule) && !Application.Current.Windows.OfType<PopupFiltrationText>().Any())
            {
                PopupFiltrationText popup = new PopupFiltrationText();
                popup.Show();
            }
        }

        private void BtnMenu(object sender, RoutedEventArgs e)
        {
            if(!gridDesktop.Children.Contains(_menuModule))
                LoadMenu();
        }

        private void BtnText(object sender, RoutedEventArgs e)
        {
            if (!gridDesktop.Children.Contains(_textModule))
                LoadText();
        }

        private void BtnSettings(object sender, RoutedEventArgs e)
        {
            if (!gridDesktop.Children.Contains(_settingsModule))
                LoadSettings();
        }

        //private void btnFuture(object sender, RoutedEventArgs e)
        //{
        //}
    }
    #endregion
}
