using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace RVS_AT
{
    public partial class MainWindow : Window
    {
        private readonly Modules.Menu _menuModule;
        private readonly FileOperator _fileOperator;
        public readonly Modules.Text _textModule;
        public readonly Modules.Settings _settingsModule;
        public UIColors uiColors = Settings.LoadColors();
        public Ftp ftpService = Settings.LoadFtp();
        public MainWindow()
        {
            InitializeComponent();
            _menuModule = new();
            _fileOperator = new();
            _textModule = new();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.FontFamily = new FontFamily("Bahnschrift");
            _settingsModule = new();
            uiColors.ChangeColor();
            ProcessingAsync();
        }

        public void ProcessingAsync()
        {
            LoadMenu();
            Task ftpFiles = FromFtpToLocalFilesUpdate();
            Task unpackedFiles = _fileOperator.UnpackerGz();
        }

        public void RestartApp()
        {
            System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            Application.Current.Shutdown();
        }

        //Grant access to the FileOperator object
        internal FileOperator GrantAccess()
        {
            return _fileOperator;
        }

        internal async Task FromFtpToLocalFilesUpdate()
        {
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
            btnMainOperations.Content = "AdminTools";
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
