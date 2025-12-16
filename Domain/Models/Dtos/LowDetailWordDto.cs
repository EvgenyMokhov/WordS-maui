using Domain.Models.DataModels;

namespace Domain.Models.Dtos;

public class LowDetailWordDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string? Answer { get; set; }
    public LowDetailWordDto(Word word)
    {
        Id = word.Id;
        Text = word.Text;
    }
}
