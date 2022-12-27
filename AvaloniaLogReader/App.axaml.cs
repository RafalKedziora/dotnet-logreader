using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaLogReader.Services;
using AvaloniaLogReader.Stores;
using AvaloniaLogReader.ViewModels;
using AvaloniaLogReader.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Data;
using Services.Interfaces;
using Services.Repositories;
using Services.Stores;
using System;
using System.IO;

namespace AvaloniaLogReader
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        private IConfiguration _configuration;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
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
            services.AddSingleton<NavigationStore>();

            services.AddSingleton(s => CreateMenuNavigationService(s));

            services.AddTransient<MenuViewModel>();

            services.AddTransient(CreateNavigationBarViewModel);
            services.AddTransient(CreateLeftNavigationBarViewModel);

            services.AddTransient(s => new TextViewModel(s.GetRequiredService<ContentStore>(), CreateTextNavigationService(s)));
            services.AddTransient(s => new SettingsViewModel(s.GetRequiredService<ContentStore>(), s.GetRequiredService<NavigationBarViewModel>(), s.GetRequiredService<LeftNavigationBarViewModel>(), CreateSettingsNavigationService(s), s.GetRequiredService<FtpDownloader>(), s.GetRequiredService<FileUnpacker>()));

            services.AddSingleton<MainViewModel>();

            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();

            var seeder = _serviceProvider.GetRequiredService<DataSeeder>();
            seeder.Seed();

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = _serviceProvider.GetService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
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