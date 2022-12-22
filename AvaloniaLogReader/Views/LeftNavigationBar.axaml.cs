using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaLogReader.Views
{
    public partial class LeftNavigationBar : UserControl
    {
        public LeftNavigationBar()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
