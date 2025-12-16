using Domain.Models.DataModels;

namespace Domain.Models.Dtos;

public class TestDto
{
    public Guid Id { get; set; }
    public double Score { get; set; }
    public DateTime Date { get; set; }
    public List<LowDetailWordDto>? TestWords { get; set; }
    public TestDto(Test test)
    {
        Id = test.Id;
        Score = test.Score;
        Date = test.Date;
    }
    public TestDto(Guid id)
    {
        Id = id;
        Score = 0;
        Date = DateTime.Now;
    }

    public TestDto()
    { 
    }
}
