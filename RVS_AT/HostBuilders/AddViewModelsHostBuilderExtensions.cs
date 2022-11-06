using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVS_AT.Services;
using RVS_AT.Stores;
using RVS_AT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton((s) => CreateMainWindowViewModel(s));

                services.AddTransient<LogsListViewModel>();
                services.AddTransient<MenuViewModel>();
                services.AddTransient<PopupFiltrationTextViewModel>();
                services.AddTransient<SettingsViewModel>();
                services.AddTransient<TextViewModel>();

                services.AddSingleton<NavigationService<LogsListViewModel>>();
                services.AddSingleton<NavigationService<MainWindowViewModel>>();
                services.AddSingleton<NavigationService<MenuViewModel>>();
                services.AddSingleton<NavigationService<PopupFiltrationTextViewModel>>();
                services.AddSingleton<NavigationService<SettingsViewModel>>();
                services.AddSingleton<NavigationService<TextViewModel>>();

            });

            return hostBuilder;
        }

        private static MainWindowViewModel CreateMainWindowViewModel(IServiceProvider services)
        {
            return MainWindowViewModel.LoadViewModel(
                services.GetRequiredService<ContentStore>(),
                services.GetRequiredService<NavigationService<MenuViewModel>>());
        }
    }
}
