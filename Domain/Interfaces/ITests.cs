using Domain.Models.Dtos;

namespace Domain.Interfaces;

public interface ITests
{
    public Task<List<TestDto>> GetTestsAsync();
    public Task<TestDto> GenerateTestAsync();
    public Task CheckResultAsync(Guid id, List<LowDetailWordDto> words);
}
