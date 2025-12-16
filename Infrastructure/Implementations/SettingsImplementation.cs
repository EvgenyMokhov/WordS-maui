using Domain.Interfaces;
using Domain.Models.DataModels;
using Domain.Models.Other;
using SQLite;
using System.IO;

namespace Infrastructure.Implementations;

public class SettingsImplementation : ISettingsRepository
{
    readonly SQLiteAsyncConnection context;

    public SettingsImplementation()
    {
        var dbPath = Path.Combine("", "words.db3");
        context = new SQLiteAsyncConnection(dbPath);
    }

    public async Task<Settings> GetSettingsAsync()
    {
        var settings = await context.Table<Settings>().FirstOrDefaultAsync();
        if (settings == null)
        {
            settings = new Settings() { TargetLanguage = Language.English, LessonsCount = 1 };
            await context.InsertAsync(settings);
        }
        return settings;
    }

    public async Task SetSettingsAsync(Settings settings)
    {
        await context.DeleteAllAsync<Settings>();
        await context.InsertAsync(settings);
    }
}
