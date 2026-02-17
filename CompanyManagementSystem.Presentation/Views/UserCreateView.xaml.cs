using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class UserCreateView : UserControl
    {
        public UserCreateView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new UserCreateViewModel(navigation);
        }
    }
}
