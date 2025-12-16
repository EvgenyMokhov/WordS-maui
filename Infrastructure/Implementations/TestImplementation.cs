using Domain.Interfaces;
using Domain.Models.DataModels;
using SQLite;

namespace Infrastructure.Implementations;

public class TestImplementation : ITestRepository
{
    readonly SQLiteAsyncConnection context;

    public TestImplementation()
    {
        var dbPath = Path.Combine("", "words.db3");
        context = new SQLiteAsyncConnection(dbPath);
    }

    public async Task AddTestResultAsync(Guid id, int score)
    {
        Test test = await context.Table<Test>().FirstOrDefaultAsync(w => w.Id == id) ?? throw new Exception("Слово не найдено");
        test.Score = score;
        await context.UpdateAsync(test);
    }

    public async Task CreateTestAsync(Guid id)
    {
        await context.InsertAsync(new Test { Id = id, Score = 0, Date = DateTime.Now });
    }

    public async Task<List<Test>> GetTestsAsync()
    {
        return await context.Table<Test>().ToListAsync();
    }
}
