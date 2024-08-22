namespace DataBase.Entities;

public class StatisticQueryEntity
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public Guid UserId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
