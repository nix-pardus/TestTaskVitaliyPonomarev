
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories.StatisticQuery;

public class StatisticQueryEntityRepository : IStatisticQueryEntityRepository
{
    private UserStatisticDbContext _context;

    public StatisticQueryEntityRepository(UserStatisticDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Add(Guid userId, DateTime from, DateTime to)
    {
        var query = new StatisticQueryEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            From = from,
            To = to,
            CreateAt = DateTime.Now,
        };

        _context.StatisticQuery.Add(query);
        await _context.SaveChangesAsync();
        return query.Id;
    }

    public async Task<StatisticQueryEntity> GetByIdAsync(Guid id)
    {
        var entry = await _context.StatisticQuery.FirstAsync(x => x.Id.Equals(id));
        return entry;
    }
}
