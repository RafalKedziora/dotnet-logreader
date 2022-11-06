using RVS_AT.Commands;
using RVS_AT.Services;
using RVS_AT.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ContentStore _contentStore;

        public ICommand OpenOperationsCommand { get; }

        public ICommand CloseAppCommand { get; }
        public ICommand MinMaxAppCommand { get; }
        public ICommand StateAppCommand { get; }

        public ICommand TextNavigateCommand { get; }
        public ICommand SettingsNavigateCommand { get; }
        public ICommand MainMenuNavigateCommand { get; }

        public MainWindowViewModel(ContentStore contentStore, NavigationService<MenuViewModel> menuNavigationService)
        {
            _contentStore = contentStore;

            CloseAppCommand = new CloseAppCommand();
            MinMaxAppCommand = new MinMaxAppCommand();
            StateAppCommand = new StateAppCommand();

            OpenOperationsCommand = new OpenOperationsCommand();
            TextNavigateCommand = new TextNavigateCommand();
            SettingsNavigateCommand = new SettingsNavigateCommand();
            MainMenuNavigateCommand = new NavigateCommand<MenuViewModel>(menuNavigationService);

        }

        public static MainWindowViewModel LoadViewModel(ContentStore contentStore, NavigationService<MenuViewModel> menuNavigationService)
        {
            var viewModel = new MainWindowViewModel(contentStore, menuNavigationService);

            viewModel.MainMenuNavigateCommand.Execute(null);

            return viewModel;
        }
    }
}
