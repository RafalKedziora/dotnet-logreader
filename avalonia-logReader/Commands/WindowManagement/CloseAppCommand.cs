using AvaloniaLogReader.Commands.BaseCommands;
using System.Windows;

namespace AvaloniaLogReader.Commands.WindowManagement
{
    public class CloseAppCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
