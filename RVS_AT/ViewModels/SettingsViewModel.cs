using RVS_AT.Commands;
using RVS_AT.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand SaveNULLCommand { get; }
        public ICommand SaveColorsCommand { get; }
        public ICommand SaveFtpCredentialsCommand { get; }

        public SettingsViewModel()
        {
            SaveColorsCommand = new SaveColorsCommand();
            SaveFtpCredentialsCommand = new SaveFtpCredentialsCommand();
            SaveNULLCommand = new SaveNULLCommand();
        }

        public SettingsViewModel(ContentStore contentStore)
        {
            this.contentStore = contentStore;
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

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
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

        private string _backgroundColor;
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }

        private string _backgroundButton;
        private ContentStore contentStore;

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
    }
}
