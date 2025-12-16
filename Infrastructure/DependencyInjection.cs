using Domain.Interfaces;
using Domain.Models.DataModels;
using Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;
using SQLite;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var dbPath = Path.Combine("", "words.db3");
        SQLiteAsyncConnection db = new SQLiteAsyncConnection(dbPath);
        try
        {
            db.CreateTableAsync<Word>();
            db.CreateTableAsync<Test>();
            db.CreateTableAsync<Settings>();
        }
        finally
        {
            
        }
        
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWordsRepository, WordsImplementation>();
        services.AddScoped<ISettingsRepository, SettingsImplementation>();
        services.AddScoped<ITestRepository, TestImplementation>();
        return services;
    }
}
