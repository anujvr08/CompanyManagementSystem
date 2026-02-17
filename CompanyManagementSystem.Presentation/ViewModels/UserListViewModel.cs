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
    /// ViewModel for the user list screen.
    /// </summary>
    public class UserListViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly UserService _userService;

        public ObservableCollection<UserDTO> Users { get; set; }

        public ICommand BackCommand { get; }

        public UserListViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _userService = new UserService(new UserRepository(new AppDbContext()), new UserMapper());

            Users = new ObservableCollection<UserDTO>();
            BackCommand = new RelayCommand(_ => GoBack());

            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var list = _userService.GetUsersByCompany(GlobalConstants.CurrentCompanyId);
                Users.Clear();
                foreach (var u in list)
                {
                    Users.Add(u);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack()
        {
            var view = new Views.DashboardView(_navigation);
            _navigation.NavigateTo(view);
        }
    }
}
