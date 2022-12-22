using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaLogReader.Views
{
    public partial class TextView : UserControl
    {
        public TextView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
