using RVS_AT.Commands.BaseCommands;
using System.Windows;

namespace RVS_AT.Commands.WindowManagement
{
    public class MinMaxAppCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
