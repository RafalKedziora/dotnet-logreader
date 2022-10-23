using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace RVS_AT
{
    public class UIColors : INotifyPropertyChanged
    {
        private Color _background;
        private Brush _backgroundButton;
        private Color _gradient1;
        private Color _gradient2;
        private Color _gradient3;

        public void ChangeColor()
        {
            ChangeColor(new []{ _gradient1.ToString(), _gradient2.ToString(), _gradient3.ToString(), _background.ToString(), _backgroundButton.ToString() } );
        }

        public void ChangeColor(string[] textColors)
        {
            App.Current.Windows.OfType<MainWindow>().FirstOrDefault().DataContext = this;

            _gradient1 = (Color)ColorConverter.ConvertFromString(textColors[0]);
            _gradient2 = (Color)ColorConverter.ConvertFromString(textColors[1]);
            _gradient3 = (Color)ColorConverter.ConvertFromString(textColors[2]);
            _background = (Color)ColorConverter.ConvertFromString(textColors[3]);
            _backgroundButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColors[4]));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
