using Avalonia.Media;
using LogsFiltering;
using LogsFiltering.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RVS_AT
{
    public class UIColors //: INotifyPropertyChanged
    {
        private Color _background;
        private Brush _backgroundButton;
        private Color _gradient1;
        private Color _gradient2;
        private Color _gradient3;

        public Color Gradient1
        {
            get { return _gradient1; }
            set
            {
                _gradient1 = value;
            }
        }

        public Color Gradient2
        {
            get { return _gradient2; }
            set
            {
                _gradient2 = value;
            }
        }

        public Color Gradient3
        {
            get { return _gradient3; }
            set
            {
                _gradient3 = value;
            }
        }

        public Color BackgroundColor
        {
            get { return _background; }
            set
            {
                _background = value;
            }
        }

        public Brush BackgroundButton
        {
            get { return _backgroundButton; }
            set
            {
                _backgroundButton = value;
            }
        }


        public void ChangeColor()
        {
            ChangeColor(new []{ Gradient1.ToString(), Gradient2.ToString(), Gradient3.ToString(), BackgroundColor.ToString(), BackgroundButton.ToString() } );
        }

        public void ChangeColor(string[] textColors)
        {
            Gradient1 = Color.Parse(textColors[0]);
            Gradient2 = Color.Parse(textColors[1]);
            Gradient3 = Color.Parse(textColors[2]);
            BackgroundColor = Color.Parse(textColors[3]);
            BackgroundButton = new SolidColorBrush(Color.Parse(textColors[4]));
        }
    }
}
