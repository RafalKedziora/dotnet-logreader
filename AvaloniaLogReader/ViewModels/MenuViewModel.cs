using AvaloniaLogReader.Stores;
using Domain.Models;
using System;
using System.IO;

namespace AvaloniaLogReader.ViewModels
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
                    Name = "latest",
                    Extension = ".log",
                    LogDate = DateTime.Now

                });
        }
    }
}
