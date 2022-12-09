using RVS_AT.Commands.BaseCommands;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.Commands
{
    public class NextDayCommand : AsyncCommandBase
    {
        private readonly TextViewModel _textViewModel;
        private readonly ContentStore _contentStore;
        public NextDayCommand(TextViewModel textViewModel, ContentStore contentStore) 
        {
            _textViewModel = textViewModel;
            _contentStore = contentStore;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return Task.FromResult(0);
        }
    }
}
