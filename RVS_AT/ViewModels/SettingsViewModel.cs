using Domain.Models;
using RVS_AT.Commands;
using RVS_AT.Commands.SettingsCommands;
using RVS_AT.Services;
using RVS_AT.Stores;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace RVS_AT.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand SaveColorsCommand { get; }
        public ICommand SaveFtpCredentialsCommand { get; }
        public ICommand LoadFtpDataCommand { get; }
        public ICommand UnpackFilesCommand { get; }
        public ICommand ResetSettings { get; }
        public ICommand RemoveAllFilesCommand { get; }

        private readonly NavigationBarViewModel _navigationBarViewModel;
        private readonly LeftNavigationBarViewModel _leftNavigationBarViewModel;

        public SettingsViewModel(ContentStore contentStore, NavigationBarViewModel navigationBarViewModel, LeftNavigationBarViewModel leftNavigationBarViewModel, INavigationService settingsNavigationService, FtpDownloader ftp, FileUnpacker fileUnpacker)
        {
            _navigationBarViewModel = navigationBarViewModel;
            _leftNavigationBarViewModel = leftNavigationBarViewModel;

            SaveColorsCommand = new SaveColorsCommand(contentStore, this);
            SaveFtpCredentialsCommand = new SaveFtpCredentialsCommand(contentStore, this);
            ResetSettings = new NavigateCommand(settingsNavigationService);
            LoadFtpDataCommand = new LoadFtpData(this, ftp);
            UnpackFilesCommand = new UnpackFilesCommand(contentStore, fileUnpacker);
            RemoveAllFilesCommand = new RemoveAllFilesCommand(Environment.CurrentDirectory + "/logs");


            LoadColors(contentStore._uiColors);
            LoadFtpCredentials(contentStore._ftpCredentials);
        }
        private void LoadColors(UIColors colors)
        {
            Gradient1 = colors.Gradient1;
            Gradient2 = colors.Gradient2;
            Gradient3 = colors.Gradient3;
            Background = colors.Background;
            BackgroundButton = colors.BackgroundButton;
        }

        public void UpdateColors(UIColors updatedColors)
        {
            _navigationBarViewModel.UpdateColors(updatedColors);
            _leftNavigationBarViewModel.UpdateColors(updatedColors);
            ResetSettings.Execute(this);
        }

        private void LoadFtpCredentials(FtpCredentials ftpCredentials)
        {
            _host = ftpCredentials.Host;
            _port = ftpCredentials.Port;
            _login = ftpCredentials.Login;
            _password = ftpCredentials.Password;
            _pathToFiles = ftpCredentials.PathToFiles;
        }

        internal void UpdateProgressBar(int current, int fileCount)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
            {
                if (fileCount > 0)
                {
                    Progress = (int)(((double)current / fileCount) * 100);
                }
                else
                {
                    Progress = 0;
                }
            }));
        }

        private string _host;
        public string Host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
                OnPropertyChanged(nameof(Host));
            }
        }

        private int _port;
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                OnPropertyChanged(nameof(Port));
            }
        }

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string SecurePassword { private get; set; }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _pathToFiles;
        public string PathToFiles
        {
            get
            {
                return _pathToFiles;
            }
            set
            {
                _pathToFiles = value;
                OnPropertyChanged(nameof(PathToFiles));
            }
        }

        private string _gradient1;
        public string Gradient1
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

        private string _gradient2;
        public string Gradient2
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

        private string _gradient3;
        public string Gradient3
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

        private int _progress;

        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }
    }
}
