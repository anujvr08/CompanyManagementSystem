using System.Windows.Input;
using CompanyManagementSystem.Presentation.Helpers;

namespace CompanyManagementSystem.Presentation.ViewModels
{
    /// <summary>
    /// ViewModel for the Main Menu - the landing page of the application.
    /// </summary>
    public class MainMenuViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;

        public ICommand CreateCompanyCommand { get; }
        public ICommand LoadCompanyCommand { get; }

        public MainMenuViewModel(NavigationService navigation)
        {
            _navigation = navigation;

            CreateCompanyCommand = new RelayCommand(_ =>
            {
                var view = new Views.CompanyCreateView(_navigation);
                _navigation.NavigateTo(view);
            });

            LoadCompanyCommand = new RelayCommand(_ =>
            {
                var view = new Views.CompanyListView(_navigation);
                _navigation.NavigateTo(view);
            });
        }
    }
}
