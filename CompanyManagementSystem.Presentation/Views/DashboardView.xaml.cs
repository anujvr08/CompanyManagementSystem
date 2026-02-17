using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new DashboardViewModel(navigation);
        }
    }
}
