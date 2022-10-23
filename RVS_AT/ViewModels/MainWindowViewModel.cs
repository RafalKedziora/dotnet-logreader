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
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand OpenOperationsCommand { get; }

        public ICommand CloseAppCommand { get; }
        public ICommand MinMaxAppCommand { get; }
        public ICommand StateAppCommand { get; }

        public ICommand TextNavigateCommand { get; }
        public ICommand SettingsNavigateCommand { get; }
        public ICommand MainMenuNavigateCommand { get; }

        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            OpenOperationsCommand = new OpenOperationsCommand();
            CloseAppCommand = new CloseAppCommand();
            MinMaxAppCommand = new MinMaxAppCommand();
            StateAppCommand = new StateAppCommand();
            TextNavigateCommand = new TextNavigateCommand();
            SettingsNavigateCommand = new SettingsNavigateCommand();
            MainMenuNavigateCommand = new MainMenuNavigateCommand();

            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
