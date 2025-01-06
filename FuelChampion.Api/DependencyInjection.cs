using FuelChampion.Api.Repositories;

namespace FuelChampion.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ICarRepository, CarRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
        services.AddSingleton<IGasStationRepository, GasStationRepository>();

        return services;
    }
}
