﻿using Domain.Models;
using RVS_AT.Commands;
using RVS_AT.Commands.WindowManagement;
using RVS_AT.Services;
using RVS_AT.Stores;
using System.Windows.Input;

namespace RVS_AT.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand OpenOperationsCommand { get; }

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

        public NavigationBarViewModel(ContentStore contentStore, INavigationService popupNavigationService)
        {
            OpenOperationsCommand = new NavigateCommand(popupNavigationService);

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
