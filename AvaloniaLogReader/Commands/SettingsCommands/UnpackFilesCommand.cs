using AvaloniaLogReader.Commands.BaseCommands;
using Services.Helpers;
using Services.Stores;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AvaloniaLogReader.Commands.SettingsCommands
{
    public class UnpackFilesCommand : AsyncCommandBase
    {
        private readonly FilesStore _filesStore;
        private readonly FileUnpacker _fileUnpacker;
        public UnpackFilesCommand(FilesStore filesStore, FileUnpacker fileUnpacker)
        {
            _filesStore = filesStore;
            _fileUnpacker = fileUnpacker;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _filesStore._files = _fileUnpacker.GetFilesToUnpack();

            foreach (var file in _filesStore._files)
            {
                if (file.Extension == ".log.gz")
                {
                    await _fileUnpacker.Decompress(new FileInfo($"{Environment.CurrentDirectory}/logs/{file.Name}{file.Extension}"));
                }
            }

            _filesStore._files = FileReader.FilterUnpacked(_filesStore._files);

        }
    }
}
