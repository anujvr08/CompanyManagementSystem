using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CompanyManagementSystem.Presentation.Helpers
{
    /// <summary>
    /// Base class for all ViewModels.
    /// Implements INotifyPropertyChanged so the UI automatically updates
    /// when a property value changes.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when a property value changes.
        /// WPF data bindings listen to this event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Call this from any property setter to notify the UI.
        /// Usage: set { _field = value; OnPropertyChanged(); }
        /// </summary>
        /// <param name="propertyName">Auto-filled by the compiler.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
