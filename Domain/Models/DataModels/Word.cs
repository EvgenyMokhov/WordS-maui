using Domain.Models.Other;
using SQLite;

namespace Domain.Models.DataModels;

public class Word
{
    [PrimaryKey]
    public Guid Id { get; set; }

    public Language Language { get; set; } 
    public string Text { get; set; }
    public string Transcription { get; set; }
    public string Translation { get; set; }
    public string Example { get; set; }
    public bool IsReviewed { get; set; }
}
