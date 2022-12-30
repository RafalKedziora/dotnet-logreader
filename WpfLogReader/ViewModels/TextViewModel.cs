using Domain.Models;
using Services.Helpers;
using Services.Stores;
using System;
using System.Linq;
using System.Windows.Input;
using WpfLogReader.Commands;
using WpfLogReader.Services;

namespace WpfLogReader.ViewModels
{
    public class TextViewModel : ViewModelBase
    {
        public ICommand PrevDayCommand { get; }
        public ICommand NextDayCommand { get; }
        public ICommand ResetTextView { get; }

        private string currentDay;
        private string logboxText;

        private readonly ContentStore _contentStore;
        private readonly FilesStore _filesStore;

        public string Background => _contentStore._uiColors.Background;
        public string BackgroundButton => _contentStore._uiColors.BackgroundButton;

        public TextViewModel(ContentStore contentStore, FilesStore filesStore, INavigationService textNavigationService)
        {
            _contentStore = contentStore;
            _filesStore = filesStore;

            NextDayCommand = new NextDayCommand(this, _filesStore);
            PrevDayCommand = new PrevDayCommand(this, _filesStore);
            ResetTextView = new NavigateCommand(textNavigationService);

            ChangeDay(_filesStore.currentFile);
        }

        public void ChangeDay(FileModel file)
        {
            if (file is null && _filesStore.Files.Any(x => x.Name == "latest"))
            {
                logboxText = FileReader.ReadFile(Environment.CurrentDirectory + $"/logs/latest.log");
                currentDay = DateTime.Today.ToString("dd.MM.yyyy");
                _filesStore.currentFile = _filesStore.Files.FirstOrDefault(x => x.Name == "latest");
            }
            else if (file is not null)
            {
                logboxText = FileReader.ReadFile(Environment.CurrentDirectory + $"/logs/{file.Name}.log");
                currentDay = file.LogDate.ToString("dd.MM.yyyy");
            }
            else
            {
                logboxText = "Nie załadowano logów";
            }
        }

        public void ResetViewModel()
        {
            ResetTextView.Execute(this);
        }

        public string CurrentDay
        {
            get
            {
                return currentDay;
            }

            set
            {
                currentDay = value;
                OnPropertyChanged(nameof(CurrentDay));
            }
        }

        public string LogboxText
        {
            get
            {
                return logboxText;
            }
            set
            {
                logboxText = value;
                OnPropertyChanged(nameof(LogboxText));
            }
        }
    }
}
