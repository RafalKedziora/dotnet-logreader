using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LogsFiltering.Views
{
    public partial class Text : UserControl
    {
        public Text()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
