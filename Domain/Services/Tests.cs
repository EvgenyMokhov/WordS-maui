using Domain.Interfaces;
using Domain.Models.Dtos;

namespace Domain.Services;

public class Tests(ITestRepository testsRepo, IWords wordsService) : ITests
{
    public async Task CheckResultAsync(Guid id, List<LowDetailWordDto> words)
    {
        double result = 0;
        int correctCount = await wordsService.CheckWordsAsync(words);
        int averageCount = words.Count;
        if (averageCount == 0)
            result = 100;
        else if (correctCount == 0)
            result = 0;
        else 
            result = (double)correctCount / (double)averageCount * 100;
        await testsRepo.AddTestResultAsync(id, (int)result);
    }

    public async Task<TestDto> GenerateTestAsync()
    {
        Guid testId = Guid.NewGuid();
        await testsRepo.CreateTestAsync(testId);
        return new(testId) { TestWords = await wordsService.GetWordsForTestAsync(10) };
    }

    public async Task<List<TestDto>> GetTestsAsync()
    {
        var data = await testsRepo.GetTestsAsync();
        return data.Select(t => new TestDto(t)).ToList();
    }
}
