using System.Windows.Controls;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.ViewModels;

namespace CompanyManagementSystem.Presentation.Views
{
    public partial class CompanyCreateView : UserControl
    {
        public CompanyCreateView(NavigationService navigation)
        {
            InitializeComponent();
            DataContext = new CompanyCreateViewModel(navigation);
        }
    }
}
