using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace LogsFiltering.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            BtnClose = ReactiveCommand.Create(() =>
            {
            
            });   
            Close = new Bitmap("../../../Assets/cancel.png");
            Minimize = new Bitmap("../../../Assets/minimize.png");
            Maximize = new Bitmap("../../../Assets/maximize.png");
        }
        public ICommand BtnClose { get; }
        public Bitmap Close { get; }
        public Bitmap Minimize { get; }
        public Bitmap Maximize { get; }
    }
}
