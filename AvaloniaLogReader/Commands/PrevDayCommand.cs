using AvaloniaLogReader.Commands.BaseCommands;
using AvaloniaLogReader.ViewModels;
using Services.Stores;
using System.Linq;

namespace AvaloniaLogReader.Commands
{
    public class PrevDayCommand : CommandBase
    {
        private readonly TextViewModel _textViewModel;
        private readonly FilesStore _filesStore;
        public PrevDayCommand(TextViewModel textViewModel, FilesStore filesStore)
        {
            _textViewModel = textViewModel;
            _filesStore = filesStore;
        }

        public override void Execute(object parameter)
        {
            if (_filesStore._files is not null)
            {
                var file = _filesStore._files.LastOrDefault(x => x.Id < _filesStore.currentFile.Id);
                if (file is not null)
                {
                    _filesStore.currentFile = file;
                    _textViewModel.ResetViewModel();
                }
            }
        }
    }
}
