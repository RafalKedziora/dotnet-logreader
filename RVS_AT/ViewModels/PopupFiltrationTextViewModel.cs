using RVS_AT.Commands;
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
        public ICommand SaveOperationsCommand { get; }
        public ICommand CloseOperationsCommand { get; }

        public PopupFiltrationTextViewModel()
        {
            SaveOperationsCommand = new SaveOperationsCommand();
            CloseOperationsCommand = new CloseOperationsCommand();
        }
    }
}
