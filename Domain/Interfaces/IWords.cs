using Domain.Models.Dtos;

namespace Domain.Interfaces;

public interface IWords
{
    public Task<WordDto> GetDailyWordAsync();
    public Task<List<LowDetailWordDto>> GetWordsForTestAsync(int count = 10);
    public Task SetWordReviewedAsync(Guid wordId);
    public Task<int> CheckWordsAsync(List<LowDetailWordDto> words);
}
