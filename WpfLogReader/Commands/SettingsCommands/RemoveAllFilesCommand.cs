using System.Collections.Generic;
using System.IO;
using WpfLogReader.Commands.BaseCommands;

namespace WpfLogReader.Commands.SettingsCommands
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
            if (Directory.Exists(_path))
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
}
