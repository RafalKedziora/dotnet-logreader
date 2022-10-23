using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVS_AT.HostBuilders;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using Services.Data;
using System.Windows;
using Microsoft.Extensions.Configuration;

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

                    services.AddSingleton(new LFDbContextFactory(connectionString));


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

            //navigate

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
