using WpfLogReader.Commands.BaseCommands;
using System.Windows;

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
