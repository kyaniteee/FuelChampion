using FuelChampion.WebUI.Services;

namespace FuelChampion.WebUI.Server;

public static class DependencyInjection
{
    public static IServiceCollection Configuration(this IServiceCollection services)
    {
        services.AddClient();
        services.AddServices();

        //services.AddOidcAuthentication(options =>
        //{
        //    builder.Configuration.Bind("OidcProvider", options.ProviderOptions);
        //});

        return services;
    }

    private static IServiceCollection AddClient(this IServiceCollection services)
    {
        services.AddScoped(client => new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7260")
        });

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ApiService>();

        return services;
    }
}
