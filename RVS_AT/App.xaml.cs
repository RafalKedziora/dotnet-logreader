using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using Services.Data;
using System.Windows;
using Microsoft.Extensions.Configuration;
using RVS_AT.Services;
using Services.Repositories;
using Services.Interfaces;
using System.Windows.Navigation;
using System;
using RVS_AT.Components;
using System.Configuration;
using System.IO;
using Services;

namespace RVS_AT
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
            services.AddTransient<Ftp>();

            services.AddTransient<IFtpCredentialsRepository, FtpCredentialsRepository>();
            services.AddTransient<IUIColorsRepository, UIColorsRepository>();

            services.AddTransient<ContentStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();

            services.AddSingleton<INavigationService>(s => CreateMenuNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            services.AddTransient<MenuViewModel>();

            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);
            services.AddTransient<LeftNavigationBarViewModel>(CreateLeftNavigationBarViewModel);

            services.AddTransient<TextViewModel>(s => new TextViewModel(s.GetRequiredService<ContentStore>()));
            services.AddTransient<SettingsViewModel>(s => new SettingsViewModel(s.GetRequiredService<ContentStore>(), s.GetRequiredService<NavigationBarViewModel>(), s.GetRequiredService<LeftNavigationBarViewModel>(), CreateSettingsNavigationService(s), s.GetRequiredService<Ftp>()));
            services.AddTransient<PopupFiltrationTextViewModel>(CreatePopupViewModel);

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
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

        private INavigationService CreatePopupNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<PopupFiltrationTextViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PopupFiltrationTextViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
                () => serviceProvider.GetRequiredService<LeftNavigationBarViewModel>());
        }

        private PopupFiltrationTextViewModel CreatePopupViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreatePopupNavigationService(serviceProvider));

            return new PopupFiltrationTextViewModel(
                serviceProvider.GetRequiredService<ContentStore>(),
                navigationService);
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                serviceProvider.GetRequiredService<ContentStore>(),
                CreatePopupNavigationService(serviceProvider));
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
