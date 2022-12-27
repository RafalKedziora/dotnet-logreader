using Services.Stores;
using System;
using System.IO;
using System.Threading.Tasks;
using WpfLogReader.Commands.BaseCommands;
using WpfLogReader.Helpers;

namespace WpfLogReader.Commands.SettingsCommands
{
    public class UnpackFilesCommand : AsyncCommandBase
    {
        private readonly ContentStore _contentStore;
        private readonly FileUnpacker _fileUnpacker;
        public UnpackFilesCommand(ContentStore contentStore, FileUnpacker fileUnpacker)
        {
            _contentStore = contentStore;
            _fileUnpacker = fileUnpacker;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _contentStore._files = _fileUnpacker.GetFilesToUnpack();

            foreach (var file in _contentStore._files)
            {
                if (file.Extension == ".log.gz")
                {
                    await _fileUnpacker.Decompress(new FileInfo($"{Environment.CurrentDirectory}/logs/{file.Name}{file.Extension}"));
                }
            }

            _contentStore._files = FileReader.FilterUnpacked(_contentStore._files);

        }
    }
}
