using RVS_AT.Models;
using RVS_AT.Stores;
using System;
using System.IO;
using System.Windows.Documents;

namespace RVS_AT.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly ContentStore _contentStore;

        public MenuViewModel(ContentStore contentStore)
        {
            _contentStore = contentStore;
            if (File.Exists(Environment.CurrentDirectory + "/logs/latest.log"))
                _contentStore._files.Add(new FileModel
                {
                    Name = "latest.log",
                    Extension = ".log",
                    LogDate = DateTime.Now
                    
                });
        }
    }
}
