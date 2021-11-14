using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RVS_AT
{
    /// <summary>
    /// Interaction logic for PopupFiltrationText.xaml
    /// </summary>
    public partial class PopupFiltrationText : Window
    {
        public PopupFiltrationText()
        {
            InitializeComponent();
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            Filtration();
        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Filtration()
        {
            MainWindow temp = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            var query = temp._textModule.logsBox.Text.Split("\n").Where(line => line.Contains(textToFind.Text));
            temp._textModule.logsBox.Text = string.Join("\n", query);
        }
    }
}
