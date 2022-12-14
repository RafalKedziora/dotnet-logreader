using RVS_AT.Commands.BaseCommands;
using RVS_AT.Helpers;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using System;
using System.Linq;

namespace RVS_AT.Commands
{
    public class PrevDayCommand : CommandBase
    {
        private readonly TextViewModel _textViewModel;
        private readonly ContentStore _contentStore;
        public PrevDayCommand(TextViewModel textViewModel, ContentStore contentStore)
        {
            _textViewModel = textViewModel;
            _contentStore = contentStore;
        }

        public override void Execute(object parameter)
        {
            if (_contentStore._files is not null)
            {
                _contentStore.currentFile = _contentStore._files.LastOrDefault(x => x.LogDate < _contentStore.currentFile.LogDate);
                _textViewModel.ResetViewModel();
            }
        }
    }
}
