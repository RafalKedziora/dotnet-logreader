using Domain.Models;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.Commands
{
    public class SaveFtpCredentialsCommand : CommandBase
    {

        private readonly ContentStore _contentStore;
        private readonly SettingsViewModel _settingsViewModel;

        public SaveFtpCredentialsCommand(ContentStore contentStore, SettingsViewModel settingsViewModel)
        {
            _contentStore = contentStore;
            _settingsViewModel = settingsViewModel;
        }

        public override void Execute(object parameter)
        {
            FtpCredentials updatedFtpCredentials = new FtpCredentials
            {
                Host = _settingsViewModel.Host,
                Login = _settingsViewModel.Login,
                Password = _settingsViewModel.Password,
                PathToFiles = _settingsViewModel.PathToFiles,
                Port = _settingsViewModel.Port,
                Id = 1
            };

            _contentStore._ftpCredentialsRepository.Update(updatedFtpCredentials);
        }
    }
}
