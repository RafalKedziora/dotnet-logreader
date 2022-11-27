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
        private ContentStore contentStore;
        private CompositeNavigationService navigationService;

        public ICommand SaveOperationsCommand { get; }
        public ICommand CloseOperationsCommand { get; }

        public PopupFiltrationTextViewModel()
        {
            SaveOperationsCommand = new SaveOperationsCommand();
            CloseOperationsCommand = new CloseOperationsCommand();
        }

        public PopupFiltrationTextViewModel(ContentStore contentStore, CompositeNavigationService navigationService)
        {
            this.contentStore = contentStore;
            this.navigationService = navigationService;
        }
    }
}
