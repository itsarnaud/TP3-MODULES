using Microsoft.Extensions.DependencyInjection;
using Hotel.Housekeeping.Contracts;

namespace Hotel.Housekeeping;

public static class ServiceRegistration
{
    public static IServiceCollection AddHousekeepingModule(this IServiceCollection services)
    {
        services.AddScoped<ICleaningPolicy, StandardCleaningPolicy>(); // Standard is the default
        services.AddScoped<IHousekeepingService, HousekeepingScheduler>();
        return services;
    }
}