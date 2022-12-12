using RVS_AT.Commands;
using RVS_AT.Stores;
using System;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    public class TextViewModel : ViewModelBase
    {
        public ICommand PrevDayCommand { get; }
        public ICommand NextDayCommand { get; }

        private string logsContent;
        private string currentDay;

        private ContentStore _contentStore;

        public string Background => _contentStore._uiColors.Background;
        public string BackgroundButton => _contentStore._uiColors.BackgroundButton;

        public TextViewModel(ContentStore contentStore)
        {
            _contentStore = contentStore;
            NextDayCommand = new NextDayCommand(this, _contentStore);
        }

        public string CurrentDay
        {
            get
            {
                return DateTime.Today.ToString();
            }
            set
            {
                currentDay = value;
                OnPropertyChanged(nameof(CurrentDay));
            }
        }

        public string LogsContent
        {
            get
            {
                return logsContent;
            }
            set
            {
                logsContent = value;
                OnPropertyChanged(nameof(LogsContent));
            }
        }
    }
}
