using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using RVS_AT;
using System.Threading;

namespace LogsFiltering.Views
{
    public partial class MainWindow : Window
    {
        //private readonly Modules.Menu _menuModule;
        //private readonly FileOperator _fileOperator;
        //public readonly Modules.Text _textModule;
        //public readonly Modules.Settings _settingsModule;
        //public UIColors uiColors;
        //public Ftp ftpService;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
                this.AttachDevTools();
#endif
            //this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            //this.FontFamily = new FontFamily("Bahnschrift");
            //LoadAppSettings();
            //_menuModule = new();
            //_fileOperator = new();
            //_textModule = new();
            //_settingsModule = new();
            //ProcessingAsync();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        //internal async void FromFtpToLocalFilesUpdate()
        //{
        //    if (ftpService != null)
        //        await ftpService.Download();
        //}

        public void RestartApp()
        {
            //System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //Application.Current.Shutdown();
        }
    }
    #region AppRun
    public partial class MainWindow : Window
    {
        //private void LoadAppSettings()
        //{
        //    ftpService = Settings.LoadFtp();
        //    uiColors = Settings.LoadColors();

        //    uiColors.ChangeColor();
        //}


        //private void ProcessingAsync()
        //{
        //    //LoadMenu();
        //    FromFtpToLocalFilesUpdate();
        //    _fileOperator.UnpackerGz();
        //}
    }
    #endregion
    #region UserControlLoading
    //public partial class MainWindow : Window
    //{
    //    private void LoadSettings()
    //    {
    //        gridDesktop.Children.Clear();
    //        gridDesktop.Children.Add(_settingsModule);
    //        btnMainOperations.Content = "AdminTools";
    //    }

    //    private void LoadText()
    //    {
    //        gridDesktop.Children.Clear();
    //        gridDesktop.Children.Add(_textModule);
    //        btnMainOperations.Content = "Operacje";
    //    }

    //    private void LoadMenu()
    //    {
    //        gridDesktop.Children.Clear();
    //        gridDesktop.Children.Add(_menuModule);
    //        btnMainOperations.Content = "AdminTools";
    //    }
    //}
    #endregion
    #region UpperBeamButtons
    public partial class MainWindow : Window
    {
        private void BtnClose(object sender, RoutedEventArgs e)
        {
        }

        private void BtnMaximize(object sender, RoutedEventArgs e)
            => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        private void BtnMinimize(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;
    }
    #endregion
    #region BtnLoadUserControls
    //public partial class MainWindow : Window
    //{
    //    private void BtnOperations(object sender, RoutedEventArgs e)
    //    {
    //        if (gridDesktop.Children.Contains(_textModule) && !Application.Current.Windows.OfType<PopupFiltrationText>().Any())
    //        {
    //            PopupFiltrationText popup = new PopupFiltrationText();
    //            popup.Show();
    //        }
    //    }

    //    private void BtnMenu(object sender, RoutedEventArgs e)
    //    {
    //        if (!gridDesktop.Children.Contains(_menuModule))
    //            LoadMenu();
    //    }

    //    private void BtnText(object sender, RoutedEventArgs e)
    //    {
    //        if (!gridDesktop.Children.Contains(_textModule))
    //            LoadText();
    //    }

    //    private void BtnSettings(object sender, RoutedEventArgs e)
    //    {
    //        if (!gridDesktop.Children.Contains(_settingsModule))
    //            LoadSettings();
    //    }

    //    //private void btnFuture(object sender, RoutedEventArgs e)
    //    //{
    //    //}
    //}
    #endregion
}
