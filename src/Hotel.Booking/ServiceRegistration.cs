using Microsoft.Extensions.DependencyInjection;
using Hotel.Booking.Contracts;

namespace Hotel.Booking;

public static class ServiceRegistration
{
    public static IServiceCollection AddBookingModule(this IServiceCollection services)
    {
        services.AddScoped<RoomAssigner>();
        services.AddScoped<IBookingService, BookingService>();
        return services;
    }
}