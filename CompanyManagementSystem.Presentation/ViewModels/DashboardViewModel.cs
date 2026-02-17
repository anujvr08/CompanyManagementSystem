using System.Windows.Input;
using CompanyManagementSystem.Application.Mappers;
using CompanyManagementSystem.Application.Services;
using CompanyManagementSystem.Domain.GlobalVars;
using CompanyManagementSystem.Infrastructure.Context;
using CompanyManagementSystem.Infrastructure.Repositories;
using CompanyManagementSystem.Presentation.Helpers;

namespace CompanyManagementSystem.Presentation.ViewModels
{
    /// <summary>
    /// ViewModel for the Dashboard - the main hub after selecting/logging into a company.
    /// </summary>
    public class DashboardViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly CompanyService _companyService;

        private string _companyName;

        public string CompanyName
        {
            get => _companyName;
            set { _companyName = value; OnPropertyChanged(); }
        }

        public ICommand CreateUserCommand { get; }
        public ICommand UserListCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public ICommand AccountListCommand { get; }
        public ICommand CloseCompanyCommand { get; }

        public DashboardViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _companyService = new CompanyService(new CompanyRepository(new AppDbContext()), new CompanyMapper());

            // Load company name for display
            var company = _companyService.GetCompanyById(GlobalConstants.CurrentCompanyId);
            if (company != null)
            {
                CompanyName = company.CompanyName;
            }

            CreateUserCommand = new RelayCommand(_ =>
            {
                var view = new Views.UserCreateView(_navigation);
                _navigation.NavigateTo(view);
            });

            UserListCommand = new RelayCommand(_ =>
            {
                var view = new Views.UserListView(_navigation);
                _navigation.NavigateTo(view);
            });

            CreateAccountCommand = new RelayCommand(_ =>
            {
                var view = new Views.AccountCreateView(_navigation);
                _navigation.NavigateTo(view);
            });

            AccountListCommand = new RelayCommand(_ =>
            {
                var view = new Views.AccountListView(_navigation);
                _navigation.NavigateTo(view);
            });

            CloseCompanyCommand = new RelayCommand(_ =>
            {
                GlobalConstants.Reset();
                var view = new Views.MainMenuView(_navigation);
                _navigation.NavigateTo(view);
            });
        }
    }
}
