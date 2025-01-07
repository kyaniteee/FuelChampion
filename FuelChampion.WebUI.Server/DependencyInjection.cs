﻿using FuelChampion.WebUI.Server.Services;

namespace FuelChampion.WebUI.Server;

public static class DependencyInjection
{
    public static IServiceCollection AddClient(this IServiceCollection services)
    {
        services.AddHttpClient<ApiService>("https", client => 
        { 
            client.BaseAddress = new Uri("https://localhost:7260"); 
        });

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ApiService>();

        return services;
    }
}
