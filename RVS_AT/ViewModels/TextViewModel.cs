using RVS_AT.Commands;
using RVS_AT.Helpers;
using RVS_AT.Stores;
using System;
using System.Linq;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    public class TextViewModel : ViewModelBase
    {
        public ICommand PrevDayCommand { get; }
        public ICommand NextDayCommand { get; }
        
        private string currentDay;
        private string logboxText;

        private readonly ContentStore _contentStore;

        public string Background => _contentStore._uiColors.Background;
        public string BackgroundButton => _contentStore._uiColors.BackgroundButton;

        public TextViewModel(ContentStore contentStore)
        {
            _contentStore = contentStore;
            NextDayCommand = new NextDayCommand(this, _contentStore);

            if (_contentStore.Files.Any(x => x.Name == "latest.log"))
            {
                logboxText = FileReader.ReadFile(Environment.CurrentDirectory + "/logs/latest.log");
                currentDay = DateTime.Today.ToString("dd.MM.yyyy");
            }
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
