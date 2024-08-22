namespace TestTaskVitaliyPonomarev.Models;

public class QueryResultModel
{
    public Guid QueryId { get; set; }
    public int Percent { get; set; }
    public UserStatisticResponse? UserStatistic { get; set; }
}
