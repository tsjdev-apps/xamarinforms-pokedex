using Microsoft.Extensions.DependencyInjection;
using Pokedex.Interfaces;
using Pokedex.Services;
using Pokedex.ViewModels;
using System;

namespace Pokedex.Init
{
    public static class Bootstrapper
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureServices()
                .ConfigureViewModels()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseService, DatabaseService>();
            services.AddSingleton<INetworkService, NetworkService>();
            services.AddSingleton<IPokemonService, PokemonService>();
            services.AddSingleton<IUriBuilderService, UriBuilderService>();

            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<OverviewPageViewModel>();

            return services;
        }
    }
}
