using System;
using System.Data.Entity;
using System.Windows;
using CompanyManagementSystem.Infrastructure.Context;

namespace CompanyManagementSystem.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Use CreateDatabaseIfNotExists - creates DB on first run, does nothing if it exists
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());

            // Force database creation now (instead of waiting for first query)
            try
            {
                using (var ctx = new AppDbContext())
                {
                    ctx.Database.Initialize(force: false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database initialization failed:\n" + ex.Message,
                    "Startup Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
