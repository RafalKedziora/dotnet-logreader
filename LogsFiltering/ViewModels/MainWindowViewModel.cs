using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
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
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            Close = new Bitmap(assets.Open(new Uri("avares://LogsFiltering/Assets/close.png")));
            Minimize = new Bitmap(assets.Open(new Uri("avares://LogsFiltering/Assets/minimize.png")));
            Maximize = new Bitmap(assets.Open(new Uri("avares://LogsFiltering/Assets/maximize.png")));

            Menu = "Menu";
            Text = "Text";
            Settings = "Settings";
        }
        public ICommand BtnClose { get; }
        public Bitmap Close { get; }
        public Bitmap Minimize { get; }
        public Bitmap Maximize { get; }
        public string Menu { get; }
        public string Text { get; }
        public string Settings { get; }
    }
}
