using Services.Helpers;
using System.Threading.Tasks;
using WpfLogReader.Commands.BaseCommands;
using WpfLogReader.ViewModels;

namespace WpfLogReader.Commands.SettingsCommands
{
    public class LoadFtpData : AsyncCommandBase
    {
        private readonly SettingsViewModel _settingsViewModel;
        private readonly FtpDownloader _ftp;

        public LoadFtpData(SettingsViewModel settingsViewModel, FtpDownloader ftp)
        {
            _settingsViewModel = settingsViewModel;
            _ftp = ftp;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var ftpData = await _ftp.GetListingAsync();

            var fileCount = ftpData.Count;

            if (fileCount > 0)
            {
                var current = 0;
                foreach (var file in ftpData)
                {
                    current++;
                    _ftp.DownloadFile(file);
                    _settingsViewModel.UpdateProgressBar(current, fileCount);
                }
            }
            else
            {
                _settingsViewModel.Progress = 0;
            }
        }
    }
}
