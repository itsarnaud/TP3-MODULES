using Microsoft.Extensions.DependencyInjection;
using Hotel.Billing.Contracts;

namespace Hotel.Billing;

public static class ServiceRegistration
{
    public static IServiceCollection AddBillingModule(this IServiceCollection services)
    {
        services.AddScoped<PricingStrategyFactory>();
        services.AddScoped<TaxCalculator>();
        services.AddScoped<InvoiceGenerator>();
        services.AddScoped<IBillingService, BillingService>();
        return services;
    }
}