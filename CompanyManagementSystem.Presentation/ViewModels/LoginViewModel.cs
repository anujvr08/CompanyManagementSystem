using System;
using System.Windows;
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
    /// ViewModel for the login screen.
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly UserService _userService;

        private string _username;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        // Password is passed via command parameter (PasswordBox doesn't support binding)

        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }

        public LoginViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _userService = new UserService(new UserRepository(new AppDbContext()), new UserMapper());

            LoginCommand = new RelayCommand(param => Login(param));
            CancelCommand = new RelayCommand(_ => GoBack());
        }

        private void Login(object parameter)
        {
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            string password = passwordBox?.Password;

            if (string.IsNullOrWhiteSpace(Username))
            {
                MessageBox.Show("Please enter a username.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var user = _userService.Authenticate(
                    GlobalConstants.CurrentCompanyId, Username, password);

                if (user != null)
                {
                    // Set current user in global state
                    GlobalConstants.CurrentUserId = user.UserId;

                    var view = new Views.DashboardView(_navigation);
                    _navigation.NavigateTo(view);
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack()
        {
            GlobalConstants.Reset();
            var view = new Views.CompanyListView(_navigation);
            _navigation.NavigateTo(view);
        }
    }
}
