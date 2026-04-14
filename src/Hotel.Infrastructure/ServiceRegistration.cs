using Microsoft.Extensions.DependencyInjection;
using Hotel.Booking.Contracts;
using Hotel.Billing.Contracts;
using Hotel.Housekeeping.Contracts;

namespace Hotel.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryReservationStore>();
        
        services.AddSingleton<IReservationRepository>(sp => sp.GetRequiredService<InMemoryReservationStore>());
        services.AddSingleton<IBillingReservationRepository>(sp => sp.GetRequiredService<InMemoryReservationStore>());
        services.AddSingleton<IHousekeepingReservationRepository>(sp => sp.GetRequiredService<InMemoryReservationStore>());

        services.AddSingleton<InMemoryRoomStore>();
        services.AddSingleton<IRoomRepository>(sp => sp.GetRequiredService<InMemoryRoomStore>());
        services.AddSingleton<IBillingRoomRepository>(sp => sp.GetRequiredService<InMemoryRoomStore>());

        services.AddScoped<EmailSender>();
        services.AddScoped<IConfirmationSender>(sp => sp.GetRequiredService<EmailSender>());
        
        services.AddScoped<ICleaningNotifier, SmsSender>();

        return services;
    }
}