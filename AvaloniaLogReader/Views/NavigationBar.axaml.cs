using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaLogReader.Views
{
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
