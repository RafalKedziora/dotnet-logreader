using RVS_AT.Commands;
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
