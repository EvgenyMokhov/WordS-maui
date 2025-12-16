using Domain.Models.DataModels;

namespace Domain.Models.Dtos;

public class WordDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string Translation { get; set; }
    public string Transcription { get; set; }
    public string Example { get; set; }
    public WordDto(Word word)
    {
        Id = word.Id;
        Text = word.Text;
        Translation = word.Translation;
        Transcription = word.Transcription;
        Example = word.Example;
    }

    public WordDto()
    { 
    }
};
