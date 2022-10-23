using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

                services.AddSingleton<MainWindowViewModel>();
            });

            return hostBuilder;
        }
    }
}
