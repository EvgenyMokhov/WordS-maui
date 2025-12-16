using Domain.Models.DataModels;
using Domain.Models.Other;

namespace Domain.Interfaces;

public interface IWordsRepository
{
    public Task<List<Word>> GetWordsAsync(Language? language = null, bool? isReviewed = null, int? count = null);
    public Task SetWordReviewedAsync(Guid id);
    public Task<Word> GetWordAsync(Guid id);
}
