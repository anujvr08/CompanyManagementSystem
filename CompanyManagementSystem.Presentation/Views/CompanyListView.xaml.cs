using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class CompanyListView : UserControl
    {
        public CompanyListView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new CompanyListViewModel(navigation);
        }
    }
}
