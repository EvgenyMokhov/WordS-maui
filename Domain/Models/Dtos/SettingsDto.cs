using Domain.Models.DataModels;
using Domain.Models.Other;

namespace Domain.Models.Dtos;

public class SettingsDto
{
    public Language TargetLanguage { get; set; }
    public int LessonsCount { get; set; }
    public SettingsDto(Settings settings)
    {
        TargetLanguage = settings.TargetLanguage;
        LessonsCount = settings.LessonsCount;
    }
}
