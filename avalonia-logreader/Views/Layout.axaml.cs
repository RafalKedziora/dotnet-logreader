using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaLogReader.Views
{
    public partial class Layout : UserControl
    {
        public Layout()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
