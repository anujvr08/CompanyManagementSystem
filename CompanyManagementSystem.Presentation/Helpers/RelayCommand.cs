using System;
using System.Windows.Input;

namespace CompanyManagementSystem.Presentation.Helpers
{
    /// <summary>
    /// A reusable ICommand implementation for MVVM.
    /// Allows binding buttons to ViewModel methods without code-behind.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Creates a new RelayCommand.
        /// </summary>
        /// <param name="execute">Action to execute when command is invoked.</param>
        /// <param name="canExecute">Optional function to determine if command can execute.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Raised when CanExecute changes. WPF listens to this automatically.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determines whether the command can execute.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Executes the command action.
        /// </summary>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
