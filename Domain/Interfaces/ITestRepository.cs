using Domain.Models.DataModels;

namespace Domain.Interfaces;

public interface ITestRepository
{
    public Task<List<Test>> GetTestsAsync();
    public Task AddTestResultAsync(Guid id, int score);
    public Task CreateTestAsync(Guid id);
}
