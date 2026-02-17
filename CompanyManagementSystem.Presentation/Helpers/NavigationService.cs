using System;
using System.Windows.Controls;

namespace CompanyManagementSystem.Presentation.Helpers
{
    /// <summary>
    /// Manages navigation between UserControls within MainWindow.
    /// Instead of opening multiple windows, we swap the content
    /// of a ContentControl in MainWindow.
    /// </summary>
    public class NavigationService
    {
        private readonly ContentControl _contentArea;

        /// <summary>
        /// Creates a NavigationService bound to a ContentControl.
        /// </summary>
        /// <param name="contentArea">The ContentControl in MainWindow that displays views.</param>
        public NavigationService(ContentControl contentArea)
        {
            _contentArea = contentArea ?? throw new ArgumentNullException(nameof(contentArea));
        }

        /// <summary>
        /// Navigate to a new view (UserControl).
        /// Replaces the current content.
        /// </summary>
        /// <param name="view">The UserControl to display.</param>
        public void NavigateTo(UserControl view)
        {
            _contentArea.Content = view;
        }

        /// <summary>
        /// Clear the current view (show nothing).
        /// </summary>
        public void Clear()
        {
            _contentArea.Content = null;
        }
    }
}
