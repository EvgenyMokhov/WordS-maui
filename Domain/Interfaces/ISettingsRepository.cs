using Domain.Models.DataModels;

namespace Domain.Interfaces;

public interface ISettingsRepository
{
    public Task<Settings> GetSettingsAsync();
    public Task SetSettingsAsync(Settings settings);
}
