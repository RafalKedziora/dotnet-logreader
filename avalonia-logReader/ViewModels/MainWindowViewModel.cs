using AvaloniaLogReader.Stores;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaLogReader.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
