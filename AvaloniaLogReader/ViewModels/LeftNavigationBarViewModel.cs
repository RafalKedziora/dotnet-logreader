using Avalonia.Media;
using AvaloniaLogReader.Commands;
using AvaloniaLogReader.Services;
using Domain.Models;
using Services.Stores;
using System.Windows.Input;

namespace AvaloniaLogReader.ViewModels
{
    public class LeftNavigationBarViewModel : ViewModelBase
    {
        public ICommand TextNavigateCommand { get; }
        public ICommand SettingsNavigateCommand { get; }
        public ICommand MainMenuNavigateCommand { get; }

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

        private Color _gradient1;

        public Color Gradient1
        {
            get
            {
                return _gradient1;
            }
            set
            {
                _gradient1 = value;
                OnPropertyChanged(nameof(Gradient1));
            }
        }

        private Color _gradient2;

        public Color Gradient2
        {
            get
            {
                return _gradient2;
            }
            set
            {
                _gradient2 = value;
                OnPropertyChanged(nameof(Gradient2));
            }
        }

        private Color _gradient3;

        public Color Gradient3
        {
            get
            {
                return _gradient3;
            }
            set
            {
                _gradient3 = value;
                OnPropertyChanged(nameof(Gradient3));
            }
        }
        public LeftNavigationBarViewModel(
            ContentStore contentStore,
            INavigationService menuNavigationService,
            INavigationService textNavigationService,
            INavigationService settingsNavigationService)
        {
            UpdateColors(contentStore._uiColors);
            TextNavigateCommand = new NavigateCommand(textNavigationService);
            SettingsNavigateCommand = new NavigateCommand(settingsNavigationService);
            MainMenuNavigateCommand = new NavigateCommand(menuNavigationService);
        }

        public void UpdateColors(UIColors updatedColors)
        {
            Gradient1 = Color.Parse(updatedColors.Gradient1);
            Gradient2 = Color.Parse(updatedColors.Gradient2);
            Gradient3 = Color.Parse(updatedColors.Gradient3);

            Background = updatedColors.Background;
        }
    }
}
