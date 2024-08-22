using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories.UserSignIn;

public class UserSignInEntityRepository : IUserSignInEntityRepository
{
    private UserStatisticDbContext _context;

    public UserSignInEntityRepository(UserStatisticDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<UserSignInEntity>> GetUserSignInsByPeriodAsync(Guid userId, DateTime from, DateTime to)
    {
        var entries = await _context.UserStatistics
            .Where(q => q.SignInTime >= from && q.SignInTime <= to)
            .ToArrayAsync();
        return entries;
    }
}
