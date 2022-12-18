using RVS_AT.Commands.BaseCommands;
using System.Collections.Generic;
using System.IO;

namespace RVS_AT.Commands.SettingsCommands
{
    public class RemoveAllFilesCommand : CommandBase
    {
        private readonly string _path;
        public RemoveAllFilesCommand(string path)
        {
            _path = path;
        }

        public override void Execute(object parameter)
        {
            IEnumerable<string> contents = Directory.EnumerateFileSystemEntries(_path);

            foreach (string path in contents)
            {
                FileAttributes attributes = File.GetAttributes(path);
                if (attributes.HasFlag(FileAttributes.Directory))
                {
                    Directory.Delete(path, true);
                }
                else
                {
                    File.Delete(path);
                }
            }
        }
    }
}
