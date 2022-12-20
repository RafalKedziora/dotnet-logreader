using AvaloniaLogReader.Commands.BaseCommands;
using AvaloniaLogReader.Stores;
using AvaloniaLogReader.ViewModels;
using System.Linq;

namespace AvaloniaLogReader.Commands
{
    public class NextDayCommand : CommandBase
    {
        private readonly TextViewModel _textViewModel;
        private readonly ContentStore _contentStore;
        public NextDayCommand(TextViewModel textViewModel, ContentStore contentStore)
        {
            _textViewModel = textViewModel;
            _contentStore = contentStore;
        }

        public override void Execute(object parameter)
        {
            if (_contentStore._files is not null)
            {
                var file = _contentStore._files.FirstOrDefault(x => x.Id > _contentStore.currentFile.Id);
                if (file is not null)
                {
                    _contentStore.currentFile = file;
                    _textViewModel.ResetViewModel();
                }
            }
        }
    }
}
