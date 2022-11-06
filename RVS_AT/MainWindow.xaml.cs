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
    }

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
}
