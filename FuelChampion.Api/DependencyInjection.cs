using FuelChampion.Api.Data;
using FuelChampion.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FuelChampion.Api;

public static class DependencyInjection
{
    public const string DEFAULT_POLICY = "AllowBlazor";

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICarRepository, CarRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        services.AddTransient<IGasStationRepository, GasStationRepository>();

        return services;
    }

    public static IServiceCollection AddContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString)
                                                           .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
        return services;
    }

    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(DEFAULT_POLICY, policy =>
            {
                policy.WithOrigins("https://localhost:7026", "http://localhost:5065")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        return services;
    }

    public static IServiceCollection ConfigureMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
