using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class UserListView : UserControl
    {
        public UserListView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new UserListViewModel(navigation);
        }
    }
}
