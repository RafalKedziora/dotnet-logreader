using RVS_AT.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    public class LogsListViewModel : ViewModelBase
    {
        public ICommand SaveLogsViewCommand { get; }
        public ICommand CloseLogsViewCommand { get; }

        public ICommand SelectLastSevenDaysCommand { get; }
        public ICommand SelectLastThreeCommand { get; }
        public ICommand SelectLastOneCommand { get; }
        public ICommand ShowSelectedCommand { get; }

        public LogsListViewModel()
        {
            SaveLogsViewCommand = new SaveLogsViewCommand();
            CloseLogsViewCommand = new CloseLogsViewCommand();
            SelectLastSevenDaysCommand = new SelectLastSevenDaysCommand();
            SelectLastThreeCommand = new SelectLastThreeCommand();
            SelectLastOneCommand = new SelectLastOneCommand();
            ShowSelectedCommand = new ShowSelectedCommand();
        }

        private string _contentFilter;
        public string ContentFilter
        {
            get
            {
                return _contentFilter;
            }
            set
            {
                _contentFilter = value;
                OnPropertyChanged(nameof(ContentFilter));
            }
        }
    }
}
