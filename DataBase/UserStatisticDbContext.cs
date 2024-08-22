using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class UserStatisticDbContext : DbContext
{
    public UserStatisticDbContext(DbContextOptions<UserStatisticDbContext> options) : base(options)
    {
    }

    public DbSet<UserSignInEntity> UserStatistics { get; init; } = null!;
    public DbSet<StatisticQueryEntity> StatisticQuery { get; init; } = null!;
}
