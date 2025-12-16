using Domain.Interfaces;
using Domain.Models.DataModels;
using Domain.Models.Dtos;

namespace Domain.Services;

public class Words(IWordsRepository wordsRepo, ISettings settingsService) : IWords
{
    public async Task SetWordReviewedAsync(Guid wordId)
    {
        await wordsRepo.SetWordReviewedAsync(wordId);
    }

    public async Task<WordDto> GetDailyWordAsync()
    {
        var settings = await settingsService.GetSettingsAsync();
        var words = await wordsRepo.GetWordsAsync(settings.TargetLanguage, false, 1);
        if (words.Count == 0)
            throw new InvalidOperationException("Нет слов (одни эмоцыи)");
        return new(words[0]);
    }

    public async Task<List<LowDetailWordDto>> GetWordsForTestAsync(int count = 10)
    {
        var settings = await settingsService.GetSettingsAsync();
        var words = await wordsRepo.GetWordsAsync(settings.TargetLanguage, true, count);
        return words.Select(w => new LowDetailWordDto(w)).ToList();
    }

    public async Task<int> CheckWordsAsync(List<LowDetailWordDto> words)
    {
        int result = 0;
        foreach (var word in words)
        { 
            Word? dbWord = await wordsRepo.GetWordAsync(word.Id);
            if (word.Answer == dbWord.Translation)
                result++;
        }
        return result;
    }
}
