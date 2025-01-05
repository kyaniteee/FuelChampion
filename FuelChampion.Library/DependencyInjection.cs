using Microsoft.Extensions.DependencyInjection;

namespace FuelChampion.Library
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLibrary(this IServiceCollection services)
        {
            return services;
        }
    }
}
