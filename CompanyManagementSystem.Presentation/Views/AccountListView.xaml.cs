using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class AccountListView : UserControl
    {
        public AccountListView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new AccountListViewModel(navigation);
        }
    }
}
