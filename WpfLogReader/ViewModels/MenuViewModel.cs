using Domain.Models;
using Services.Stores;
using System;
using System.IO;

namespace WpfLogReader.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly FilesStore _filesStore;

        public MenuViewModel(FilesStore filesStore)
        {
            _filesStore = filesStore;
            if (File.Exists(Environment.CurrentDirectory + "/logs/latest.log"))
                _filesStore._files.Add(new FileModel
                {
                    Name = "latest",
                    Extension = ".log",
                    LogDate = DateTime.Now

                });
        }
    }
}
