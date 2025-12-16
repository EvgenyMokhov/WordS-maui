using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IWords, Words>();
        services.AddScoped<ISettings, Settings>();
        services.AddScoped<ITests, Tests>();
        return services;
    }
}
