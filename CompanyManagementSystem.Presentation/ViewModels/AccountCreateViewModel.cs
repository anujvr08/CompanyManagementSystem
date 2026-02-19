using System;
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
    /// ViewModel for creating a new account.
    /// </summary>
    public class AccountCreateViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly AccountService _accountService;

        private string _accountName;
        private string _group;
        private string _balance;

        public string AccountName
        {
            get => _accountName;
            set { _accountName = value; OnPropertyChanged(); }
        }

        public string Group
        {
            get => _group;
            set { _group = value; OnPropertyChanged(); }
        }

        public string Balance
        {
            get => _balance;
            set { _balance = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AccountCreateViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _accountService = new AccountService(new AccountRepository(new AppDbContext()), new AccountMapper());

            Balance = "0";

            SaveCommand = new RelayCommand(_ => SaveAccount());
            CancelCommand = new RelayCommand(_ => GoBack());
        }

        private void SaveAccount()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(AccountName))
                {
                    MessageBox.Show("Account Name is required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Group))
                {
                    MessageBox.Show("Group is required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                decimal balanceValue = 0;
                if (!string.IsNullOrWhiteSpace(Balance))
                {
                    if (!decimal.TryParse(Balance, out balanceValue))
                    {
                        MessageBox.Show("Balance must be a valid number.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                var dto = new AccountDTO
                {
                    AccountName = AccountName,
                    Group = Group,
                    Balance = balanceValue,
                    CompanyId = GlobalConstants.CurrentCompanyId,
                    UserId = GlobalConstants.CurrentUserId
                };

                _accountService.SaveAccount(dto);
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack()
        {
            var view = new Views.DashboardView(_navigation);
            _navigation.NavigateTo(view);
        }
    }
}
