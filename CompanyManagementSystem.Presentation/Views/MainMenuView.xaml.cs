using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class MainMenuView : UserControl
    {
        public MainMenuView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new MainMenuViewModel(navigation);
        }
    }
}
