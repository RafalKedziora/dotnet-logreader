﻿using Domain.Models;
using Services.Stores;
using System.Windows.Input;
using WpfLogReader.Commands.WindowManagement;

namespace WpfLogReader.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand CloseAppCommand { get; }
        public ICommand MinMaxAppCommand { get; }
        public ICommand StateAppCommand { get; }

        private string _background;
        public string Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                OnPropertyChanged(nameof(Background));
            }
        }

        private string _backgroundButton;
        public string BackgroundButton
        {
            get
            {
                return _backgroundButton;
            }
            set
            {
                _backgroundButton = value;
                OnPropertyChanged(nameof(BackgroundButton));
            }
        }

        public NavigationBarViewModel(ContentStore contentStore)
        {
            CloseAppCommand = new CloseAppCommand();
            MinMaxAppCommand = new MinMaxAppCommand();
            StateAppCommand = new StateAppCommand();

            UpdateColors(contentStore._uiColors);
        }
        internal void UpdateColors(UIColors updatedColors)
        {
            Background = updatedColors.Background;
            BackgroundButton = updatedColors.BackgroundButton;
        }
    }
}
