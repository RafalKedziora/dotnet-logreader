using ABI.Windows.UI;
using Domain.Models;
using RVS_AT.Commands.BaseCommands;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using Services.Interfaces;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace RVS_AT.Commands.SettingsCommands
{
    public class SaveColorsCommand : CommandBase
    {

        private readonly ContentStore _contentStore;
        private readonly SettingsViewModel _settingsViewModel;

        public SaveColorsCommand(ContentStore contentStore, SettingsViewModel settingsViewModel)
        {
            _contentStore = contentStore;
            _settingsViewModel = settingsViewModel;

        }

        public override void Execute(object parameter)
        {
            UIColors updateUIColors = new UIColors
            {
                Gradient1 = _settingsViewModel.Gradient1,
                Gradient2 = _settingsViewModel.Gradient2,
                Gradient3 = _settingsViewModel.Gradient3,
                Background = _settingsViewModel.Background,
                BackgroundButton = _settingsViewModel.BackgroundButton,
                Id = 1
            };

            _contentStore._uiColorsRepository.Update(updateUIColors);
            _settingsViewModel.UpdateColors(updateUIColors);
        }
    }
}
