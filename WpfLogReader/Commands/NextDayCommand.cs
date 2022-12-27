using Services.Stores;
using System.Linq;
using WpfLogReader.Commands.BaseCommands;
using WpfLogReader.ViewModels;

namespace WpfLogReader.Commands
{
    public class NextDayCommand : CommandBase
    {
        private readonly TextViewModel _textViewModel;
        private readonly FilesStore _filesStore;
        public NextDayCommand(TextViewModel textViewModel, FilesStore filesStore)
        {
            _textViewModel = textViewModel;
            _filesStore = filesStore;
        }

        public override void Execute(object parameter)
        {
            if (_filesStore._files is not null)
            {
                var file = _filesStore._files.FirstOrDefault(x => x.Id > _filesStore.currentFile.Id);
                if (file is not null)
                {
                    _filesStore.currentFile = file;
                    _textViewModel.ResetViewModel();
                }
            }
        }
    }
}
