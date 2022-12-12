using RVS_AT.Commands.BaseCommands;
using RVS_AT.Stores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.Commands.SettingsCommands
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

            foreach(var file in _contentStore._files)
            {
                await _fileUnpacker.Decompress(new FileInfo(Environment.CurrentDirectory + "/logs/" + file.Name));
            }
        }
    }
}
