using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CompanyManagementSystem.Application.Mappers;
using CompanyManagementSystem.Application.Services;
using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Infrastructure.Context;
using CompanyManagementSystem.Infrastructure.Repositories;
using CompanyManagementSystem.Presentation.Helpers;

namespace CompanyManagementSystem.Presentation.ViewModels
{
    /// <summary>
    /// ViewModel for the account list screen.
    /// Shows accounts based on current user context.
    /// </summary>
    public class AccountListViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly AccountService _accountService;

        public ObservableCollection<AccountDTO> Accounts { get; set; }

        public ICommand BackCommand { get; }

        public AccountListViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _accountService = new AccountService(new AccountRepository(new AppDbContext()), new AccountMapper());

            Accounts = new ObservableCollection<AccountDTO>();
            BackCommand = new RelayCommand(_ => GoBack());

            LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                var list = _accountService.GetAccountsForCurrentUser();
                Accounts.Clear();
                foreach (var a in list)
                {
                    Accounts.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack()
        {
            var view = new Views.DashboardView(_navigation);
            _navigation.NavigateTo(view);
        }
    }
}
