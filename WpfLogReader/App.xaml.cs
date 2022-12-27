using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Data;
using Services.Helpers;
using Services.Interfaces;
using Services.Repositories;
using Services.Stores;
using System;
using System.IO;
using System.Windows;
using WpfLogReader.Services;
using WpfLogReader.Stores;
using WpfLogReader.ViewModels;

namespace WpfLogReader
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            string connectionString = _configuration.GetConnectionString("Default");

            services.AddDbContext<LFContext>(options => options.UseSqlite(connectionString));
            services.AddTransient<DataSeeder>();
            services.AddTransient<FtpDownloader>();
            services.AddTransient<FileUnpacker>();

            services.AddTransient<IFtpCredentialsRepository, FtpCredentialsRepository>();
            services.AddTransient<IUIColorsRepository, UIColorsRepository>();

            services.AddTransient<ContentStore>();
            services.AddSingleton<FilesStore>();
            services.AddSingleton<NavigationStore>();

            services.AddSingleton(s => CreateMenuNavigationService(s));

            services.AddTransient<MenuViewModel>();

            services.AddTransient(CreateNavigationBarViewModel);
            services.AddTransient(CreateLeftNavigationBarViewModel);

            services.AddTransient(s => new TextViewModel(s.GetRequiredService<ContentStore>(), s.GetRequiredService<FilesStore>(), CreateTextNavigationService(s)));
            services.AddTransient(s => new SettingsViewModel(s.GetRequiredService<ContentStore>(), s.GetRequiredService<FilesStore>(), s.GetRequiredService<NavigationBarViewModel>(), s.GetRequiredService<LeftNavigationBarViewModel>(), CreateSettingsNavigationService(s), s.GetRequiredService<FtpDownloader>(), s.GetRequiredService<FileUnpacker>()));

            services.AddSingleton<MainViewModel>();

            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var seeder = _serviceProvider.GetRequiredService<DataSeeder>();
            seeder.Seed();

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateMenuNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MenuViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MenuViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
                () => serviceProvider.GetRequiredService<LeftNavigationBarViewModel>());
        }

        private INavigationService CreateSettingsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<SettingsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SettingsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
                () => serviceProvider.GetRequiredService<LeftNavigationBarViewModel>());
        }

        private INavigationService CreateTextNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<TextViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<TextViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
                () => serviceProvider.GetRequiredService<LeftNavigationBarViewModel>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<ContentStore>());
        }
        private LeftNavigationBarViewModel CreateLeftNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new LeftNavigationBarViewModel(
                serviceProvider.GetRequiredService<ContentStore>(),
                CreateMenuNavigationService(serviceProvider),
                CreateTextNavigationService(serviceProvider),
                CreateSettingsNavigationService(serviceProvider));
        }
    }
}
