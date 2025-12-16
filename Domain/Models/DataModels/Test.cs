using SQLite;

namespace Domain.Models.DataModels;

public class Test
{
    [PrimaryKey]
    public Guid Id { get; set; }
    public double Score { get; set; }
    public DateTime Date { get; set; }
}

