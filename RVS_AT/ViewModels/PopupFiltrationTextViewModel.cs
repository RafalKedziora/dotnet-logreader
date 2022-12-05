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
    public class PopupFiltrationTextViewModel : ViewModelBase
    {
        private ContentStore _contentStore;
        private CompositeNavigationService _navigationService;

        public ICommand SaveOperationsCommand { get; }
        public ICommand CloseOperationsCommand { get; }

        public PopupFiltrationTextViewModel(ContentStore contentStore, CompositeNavigationService navigationService)
        {
            _contentStore = contentStore;
            _navigationService = navigationService;

            SaveOperationsCommand = new SaveOperationsCommand();
            CloseOperationsCommand = new CloseOperationsCommand();
        }
    }
}
