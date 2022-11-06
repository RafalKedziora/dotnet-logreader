using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVS_AT.HostBuilders;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using Services.Data;
using System.Windows;
using Microsoft.Extensions.Configuration;
using RVS_AT.Services;
using Services.Repositories;
using Services.Interfaces;

namespace RVS_AT
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((hostContext, services) =>
                {
                    string connectionString = hostContext.Configuration.GetConnectionString("Default");

                    services.AddTransient<IFtpCredentialsRepository, FtpCredentialsRepository>();
                    services.AddTransient<IUIColorsRepository, UIColorsRepository>();

                    services.AddSingleton(new LFDbContextFactory(connectionString));
                    services.AddSingleton<ContentStore>();
                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainWindowViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            LFDbContextFactory lFDbContextFactory = _host.Services.GetRequiredService<LFDbContextFactory>();
            using (LFContext dbContext = lFDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            NavigationService<MainWindowViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<MainWindowViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
