using RVS_AT.Commands;
using RVS_AT.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    public class TextViewModel : ViewModelBase 
    {
        public ICommand PrevDayCommand { get; }
        public ICommand NextDayCommand { get; }

        public TextViewModel()
        {
            PrevDayCommand = new PrevDayCommand();
            NextDayCommand = new NextDayCommand();
        }

        public TextViewModel(ContentStore contentStore)
        {
            this.contentStore = contentStore;
        }

        private string currentDay;
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

        private string logsContent;
        private ContentStore contentStore;

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
