using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaLogReader.ViewModels;

namespace AvaloniaLogReader.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
