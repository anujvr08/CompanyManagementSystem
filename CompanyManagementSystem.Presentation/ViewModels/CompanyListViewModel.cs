using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CompanyManagementSystem.Application.Mappers;
using CompanyManagementSystem.Application.Services;
using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Domain.GlobalVars;
using CompanyManagementSystem.Infrastructure.Context;
using CompanyManagementSystem.Infrastructure.Repositories;
using CompanyManagementSystem.Presentation.Helpers;

namespace CompanyManagementSystem.Presentation.ViewModels
{
    /// <summary>
    /// ViewModel for the company list / selection screen.
    /// </summary>
    public class CompanyListViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly CompanyService _companyService;

        private CompanyDTO _selectedCompany;

        public ObservableCollection<CompanyDTO> Companies { get; set; }

        public CompanyDTO SelectedCompany
        {
            get => _selectedCompany;
            set { _selectedCompany = value; OnPropertyChanged(); }
        }

        public ICommand SelectCompanyCommand { get; }
        public ICommand BackCommand { get; }

        public CompanyListViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _companyService = new CompanyService(new CompanyRepository(new AppDbContext()), new CompanyMapper());

            Companies = new ObservableCollection<CompanyDTO>();
            SelectCompanyCommand = new RelayCommand(_ => SelectCompany());
            BackCommand = new RelayCommand(_ => GoBack());

            LoadCompanies();
        }

        private void LoadCompanies()
        {
            try
            {
                var list = _companyService.ListCompanies();
                Companies.Clear();
                foreach (var c in list)
                {
                    Companies.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading companies: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectCompany()
        {
            if (SelectedCompany == null)
            {
                MessageBox.Show("Please select a company.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Set global state
            GlobalConstants.CurrentCompanyId = SelectedCompany.CompanyId;

            // Check if company has users → if yes, go to Login; otherwise go to Dashboard
            bool hasUsers = _companyService.HasUsers(SelectedCompany.CompanyId);

            if (hasUsers)
            {
                var view = new Views.LoginView(_navigation);
                _navigation.NavigateTo(view);
            }
            else
            {
                // No users - skip login, go directly to dashboard
                GlobalConstants.CurrentUserId = 0;
                var view = new Views.DashboardView(_navigation);
                _navigation.NavigateTo(view);
            }
        }

        private void GoBack()
        {
            GlobalConstants.Reset();
            var view = new Views.MainMenuView(_navigation);
            _navigation.NavigateTo(view);
        }
    }
}
