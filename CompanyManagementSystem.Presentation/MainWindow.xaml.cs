using System.Windows;
using CompanyManagementSystem.Presentation.Helpers;
using CompanyManagementSystem.Presentation.Views;

namespace CompanyManagementSystem.Presentation
{
    /// <summary>
    /// Main application window.
    /// Contains a ContentControl where views are swapped by NavigationService.
    /// </summary>
    public partial class MainWindow : Window
    {
        public NavigationService Navigation { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            // Create NavigationService bound to the ContentControl
            Navigation = new NavigationService(MainContent);

            // Navigate to the Main Menu on startup
            Loaded += (s, e) =>
            {
                var mainMenu = new MainMenuView(Navigation);
                Navigation.NavigateTo(mainMenu);
            };
        }
    }
}

