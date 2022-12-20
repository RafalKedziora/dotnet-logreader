using System.Windows;
using WpfLogReader.Commands.BaseCommands;

namespace WpfLogReader.Commands.WindowManagement
{
    public class CloseAppCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
