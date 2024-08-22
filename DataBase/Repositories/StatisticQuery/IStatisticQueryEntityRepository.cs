using DataBase.Entities;

namespace DataBase.Repositories.StatisticQuery;

public interface IStatisticQueryEntityRepository
{
    Task<Guid> Add(Guid userId, DateTime from, DateTime to);
    Task<StatisticQueryEntity> GetByIdAsync(Guid id);
}
