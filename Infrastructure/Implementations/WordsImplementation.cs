using Domain.Interfaces;
using Domain.Models.DataModels;
using Domain.Models.Other;
using SQLite;

namespace Infrastructure.Implementations;

public class WordsImplementation : IWordsRepository
{
    readonly SQLiteAsyncConnection context;

    public WordsImplementation()
    {
        var dbPath = Path.Combine("", "words.db3");
        context = new SQLiteAsyncConnection(dbPath);
    }

    public async Task<Word> GetWordAsync(Guid id)
    {
        return await context.Table<Word>().FirstOrDefaultAsync(w => w.Id == id) ?? throw new Exception("Слово не найдено");
    }

    public async Task<List<Word>> GetWordsAsync(Language? language = null, bool? isReviewed = null, int? count = null)
    {
        string sql;
        object[] args;
        if (count.HasValue)
        {
            sql = @"SELECT * FROM Word
            WHERE (@language IS NULL OR Language = @language)
              AND (@isReviewed IS NULL OR IsReviewed = @isReviewed)
            ORDER BY RANDOM()
            LIMIT COALESCE(@count, 9223372036854775807);";
            args = new object[] { language.Value, isReviewed, count };
        }
        else
        {
            sql = @"SELECT * FROM Word
            WHERE (@language IS NULL OR Language = @language)
              AND (@isReviewed IS NULL OR IsReviewed = @isReviewed);";
            args = new object[] { language.Value, isReviewed };
        }
        var data = await context.QueryAsync<Word>(sql, args);
        //var data = context.Table<Word>()
        //    .Where(w => language == null || w.Language == language)
        //    .Where(w => isReviewed == null || w.IsReviewed == isReviewed);
        //if (count != null)
        //    data = data.OrderBy(w => Guid.NewGuid()).Take((int)count);
        return data;
    }

    public async Task SetWordReviewedAsync(Guid id)
    {
        Word word = await GetWordAsync(id);
        word.IsReviewed = true;
        await context.UpdateAsync(word);
    }
}
