using Data;
using RVS_AT.Commands;
using RVS_AT.Services;
using RVS_AT.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RVS_AT.ViewModels
{
    public class LeftNavigationBarViewModel : ViewModelBase
    {
        public readonly ContentStore _contentStore;

        public ICommand TextNavigateCommand { get; }
        public ICommand SettingsNavigateCommand { get; }
        public ICommand MainMenuNavigateCommand { get; }

        public string BackgroundButton => _contentStore._uiColors.BackgroundButton;
        public string Background => _contentStore._uiColors.Background;

        public Color Gradient1 => (Color)ColorConverter.ConvertFromString(_contentStore._uiColors.Gradient1);
        public Color Gradient2 => (Color)ColorConverter.ConvertFromString(_contentStore._uiColors.Gradient2);
        public Color Gradient3 => (Color)ColorConverter.ConvertFromString(_contentStore._uiColors.Gradient3);


        public LeftNavigationBarViewModel(
            ContentStore contentStore,
            INavigationService menuNavigationService,
            INavigationService textNavigationService,
            INavigationService settingsNavigationService)
        {
            _contentStore = contentStore;

            TextNavigateCommand = new NavigateCommand(textNavigationService);
            SettingsNavigateCommand = new NavigateCommand(settingsNavigationService);
            MainMenuNavigateCommand = new NavigateCommand(menuNavigationService);
        }
    }
}
