using AvaloniaLogReader.Stores;
using Domain.Models;

namespace AvaloniaLogReader.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private string _background;
        public string Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                OnPropertyChanged(nameof(Background));
            }
        }

        private string _backgroundButton;
        public string BackgroundButton
        {
            get
            {
                return _backgroundButton;
            }
            set
            {
                _backgroundButton = value;
                OnPropertyChanged(nameof(BackgroundButton));
            }
        }

        public NavigationBarViewModel(ContentStore contentStore)
        {
            UpdateColors(contentStore._uiColors);
        }
        internal void UpdateColors(UIColors updatedColors)
        {
            Background = updatedColors.Background;
            BackgroundButton = updatedColors.BackgroundButton;
        }
    }
}
