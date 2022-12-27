using Domain.Models;
using Services.Stores;

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

        public NavigationBarViewModel(ContentStore contentStore)
        {
            UpdateColors(contentStore._uiColors);
        }
        internal void UpdateColors(UIColors updatedColors)
        {
            Background = updatedColors.Background;
        }
    }
}
