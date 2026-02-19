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
    /// ViewModel for creating a new user within the current company.
    /// </summary>
    public class UserCreateViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly UserService _userService;

        private string _userName;

        public string UserName
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(); }
        }

        // Password is passed via command parameter

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public UserCreateViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _userService = new UserService(new UserRepository(new AppDbContext()), new UserMapper());

            SaveCommand = new RelayCommand(param => SaveUser(param));
            CancelCommand = new RelayCommand(_ => GoBack());
        }

        private void SaveUser(object parameter)
        {
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            string password = passwordBox?.Password;

            try
            {
                if (string.IsNullOrWhiteSpace(UserName))
                {
                    MessageBox.Show("Username is required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password is required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var dto = new UserDTO
                {
                    UserName = UserName?.Trim() ?? "",
                    Password = password?.Trim() ?? "",
                    CompanyId = GlobalConstants.CurrentCompanyId
                };

                _userService.SaveUser(dto);
                MessageBox.Show("User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
