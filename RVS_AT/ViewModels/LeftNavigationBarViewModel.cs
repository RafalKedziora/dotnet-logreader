using Data;
using RVS_AT.Commands;
using RVS_AT.Services;
using RVS_AT.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    internal class LeftNavigationBarViewModel : ViewModelBase
    {
        public readonly ContentStore _contentStore;

        public ICommand TextNavigateCommand { get; }
        public ICommand SettingsNavigateCommand { get; }
        public ICommand MainMenuNavigateCommand { get; }

        public string BackgroundButton => _contentStore._uiColors.BackgroundButton;
        public string Background => _contentStore._uiColors.Background;

        public string Gradient1 => _contentStore._uiColors.Gradient1;
        public string Gradient2 => _contentStore._uiColors.Gradient2;
        public string Gradient3 => _contentStore._uiColors.Gradient3;


        public LeftNavigationBarViewModel(
            ContentStore contentStore,
            INavigationService menuNavigationService,
            INavigationService settingsNavigationService,
            INavigationService textNavigationService)
        {
            _contentStore = contentStore;

            TextNavigateCommand = new NavigateCommand(textNavigationService);
            SettingsNavigateCommand = new NavigateCommand(settingsNavigationService);
            MainMenuNavigateCommand = new NavigateCommand(menuNavigationService);
        }
    }
}
