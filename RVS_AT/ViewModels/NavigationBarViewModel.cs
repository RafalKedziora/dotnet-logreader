using Domain.Models;
using RVS_AT.Commands;
using RVS_AT.Commands.WindowManagement;
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
        public ICommand OpenOperationsCommand { get; }

        public ICommand CloseAppCommand { get; }
        public ICommand MinMaxAppCommand { get; }
        public ICommand StateAppCommand { get; }

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

        public NavigationBarViewModel(ContentStore contentStore, INavigationService popupNavigationService)
        {
            OpenOperationsCommand = new NavigateCommand(popupNavigationService);

            CloseAppCommand = new CloseAppCommand();
            MinMaxAppCommand = new MinMaxAppCommand();
            StateAppCommand = new StateAppCommand();

            UpdateColors(contentStore._uiColors);
        }
        internal void UpdateColors(UIColors updatedColors)
        {
            Background = updatedColors.Background;
        }
    }
}
