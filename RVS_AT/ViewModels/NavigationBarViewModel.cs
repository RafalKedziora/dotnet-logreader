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
using Windows.ApplicationModel.Contacts;

namespace RVS_AT.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly ContentStore _contentStore;

        public ICommand OpenOperationsCommand { get; }

        public ICommand CloseAppCommand { get; }
        public ICommand MinMaxAppCommand { get; }
        public ICommand StateAppCommand { get; }

        public string BackgroundColor => _contentStore._uiColors.Background;

        public NavigationBarViewModel(ContentStore contentStore, INavigationService popupNavigationService)
        {
            _contentStore = contentStore;
            OpenOperationsCommand = new NavigateCommand(popupNavigationService);

            CloseAppCommand = new CloseAppCommand();
            MinMaxAppCommand = new MinMaxAppCommand();
            StateAppCommand = new StateAppCommand();
        }
    }
}
