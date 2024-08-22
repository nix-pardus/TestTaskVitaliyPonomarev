using DataBase.Entities;

namespace DataBase.Repositories.UserSignIn;

public interface IUserSignInEntityRepository
{
    Task<IReadOnlyCollection<UserSignInEntity>> GetUserSignInsByPeriodAsync(Guid userId, DateTime from, DateTime to);
}
