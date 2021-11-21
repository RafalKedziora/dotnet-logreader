using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public Color Gradient1
        {
            get { return _gradient1; }
            set { _gradient1 = value; OnPropertyChanged("Color"); }
        }

        public Color Gradient2
        {
            get { return _gradient2; }
            set { _gradient2 = value; OnPropertyChanged("Color"); }
        }

        public Color Gradient3
        {
            get { return _gradient3; }
            set { _gradient3 = value; OnPropertyChanged("Color"); }
        }

        public Color BackgroundColor
        {
            get { return _background; }
            set { _background = value; OnPropertyChanged("Background"); }
        }

        public Brush BackgroundButton
        {
            get { return _backgroundButton; }
            set { _backgroundButton = value; OnPropertyChanged("Background"); }
        }

        public void ChangeColor()
        {
            ChangeColor(new []{ "#FF141E30", "#FF141E30", "#FF243B55", "#FF141E30", "#FF141E30"} );
        }

        public void ChangeColor(string[] textColors)
        {
            App.Current.MainWindow.DataContext = this;

            Gradient1 = (Color)ColorConverter.ConvertFromString(textColors[0]);
            Gradient2 = (Color)ColorConverter.ConvertFromString(textColors[1]);
            Gradient3 = (Color)ColorConverter.ConvertFromString(textColors[2]);
            BackgroundColor = (Color)ColorConverter.ConvertFromString(textColors[3]);
            BackgroundButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColors[4]));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
