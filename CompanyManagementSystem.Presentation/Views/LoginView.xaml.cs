using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new LoginViewModel(navigation);
        }
    }
}
