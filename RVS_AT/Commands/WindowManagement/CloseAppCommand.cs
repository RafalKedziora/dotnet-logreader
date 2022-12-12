using RVS_AT.Commands.BaseCommands;
using System.Windows;

namespace RVS_AT.Commands.WindowManagement
{
    public class CloseAppCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
