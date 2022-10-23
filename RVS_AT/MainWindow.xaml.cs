using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace RVS_AT
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.FontFamily = new FontFamily("Bahnschrift");
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void RestartApp()
        {
            System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            Application.Current.Shutdown();
        }
    }

    //#region UpperBeamButtons
    //public partial class MainWindow : Window
    //{
    //    private void BtnClose(object sender, RoutedEventArgs e)
    //        => Application.Current.Shutdown();

    //    private void BtnMaximize(object sender, RoutedEventArgs e)
    //        => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

    //    private void BtnMinimize(object sender, RoutedEventArgs e)
    //        => WindowState = WindowState.Minimized;
    //}
    //#endregion
    //#region BtnLoadUserControls
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

    //    private void btnFuture(object sender, RoutedEventArgs e)
    //    {
    //    }
    //}
    //#endregion
}
