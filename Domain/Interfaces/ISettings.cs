using Domain.Models.Dtos;

namespace Domain.Interfaces;

public interface ISettings
{
    public Task<SettingsDto> GetSettingsAsync();
    public Task UpdateSettingsAsync(SettingsDto settingsDto);
}
