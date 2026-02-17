using System;
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
    /// ViewModel for creating a new company.
    /// </summary>
    public class CompanyCreateViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;
        private readonly CompanyService _companyService;

        private string _companyName;
        private string _gstin;
        private string _country;
        private string _state;

        public string CompanyName
        {
            get => _companyName;
            set { _companyName = value; OnPropertyChanged(); }
        }

        public string GSTIN
        {
            get => _gstin;
            set { _gstin = value; OnPropertyChanged(); }
        }

        public string Country
        {
            get => _country;
            set { _country = value; OnPropertyChanged(); }
        }

        public string State
        {
            get => _state;
            set { _state = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public CompanyCreateViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _companyService = new CompanyService(new CompanyRepository(new AppDbContext()), new CompanyMapper());

            SaveCommand = new RelayCommand(_ => SaveCompany());
            CancelCommand = new RelayCommand(_ => GoBack());
        }

        private void SaveCompany()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CompanyName))
                {
                    MessageBox.Show("Company Name is required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var dto = new CompanyDTO
                {
                    CompanyName = CompanyName,
                    GSTIN = GSTIN,
                    Country = Country,
                    State = State
                };

                _companyService.SaveCompany(dto);
                MessageBox.Show("Company created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack()
        {
            var view = new Views.MainMenuView(_navigation);
            _navigation.NavigateTo(view);
        }
    }
}
