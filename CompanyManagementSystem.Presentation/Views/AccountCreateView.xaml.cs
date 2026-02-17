using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class AccountCreateView : UserControl
    {
        public AccountCreateView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new AccountCreateViewModel(navigation);
        }
    }
}
