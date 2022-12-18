using AvaloniaLogReader.Commands.BaseCommands;
using System.Windows;

namespace AvaloniaLogReader.Commands.WindowManagement
{
    public class MinMaxAppCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
