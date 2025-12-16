using Domain.Interfaces;
using Domain.Models.Dtos;

namespace Domain.Services;

public class Settings(ISettingsRepository settingsRepo) : ISettings
{
    public async Task<SettingsDto> GetSettingsAsync()
    {
        return new(await settingsRepo.GetSettingsAsync());
    }

    public async Task UpdateSettingsAsync(SettingsDto settingsDto)
    {
        await settingsRepo.SetSettingsAsync(new() { LessonsCount = settingsDto.LessonsCount, TargetLanguage = settingsDto.TargetLanguage });
    }
}
