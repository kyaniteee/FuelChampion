using FuelChampion.Api.Repositories;
using FuelChampion.Library.Repositories;

namespace FuelChampion.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddLibrary(this IServiceCollection services)
    {
        services.AddSingleton<ICarRepository, CarRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
        services.AddSingleton<IGasStationRepository, GasStationRepository>();

        return services;
    }
}
