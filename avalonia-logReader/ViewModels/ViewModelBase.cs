using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace AvaloniaLogReader.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Release managed resources
                }

                // Release unmanaged resources
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
