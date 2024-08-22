using DataBase.Repositories.StatisticQuery;
using DataBase.Repositories.UserSignIn;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestTaskVitaliyPonomarev.Models;

namespace TestTaskVitaliyPonomarev.Controllers;

[ApiController]
[Route("report")]
public class UserStatisticController : ControllerBase
{
    private IStatisticQueryEntityRepository StatisticQueryEntityRepository { get; }
    private IUserSignInEntityRepository UserSignInEntityRepository { get; }
    private IOptionsMonitor<UserSignInStatisticsOptions> UserSignInStatisticsOptions { get; }

    public UserStatisticController(IStatisticQueryEntityRepository statisticQueryEntityRepository, IOptionsMonitor<UserSignInStatisticsOptions> userSignInStatisticsOptions, IUserSignInEntityRepository userSignInEntityRepository)
    {
        StatisticQueryEntityRepository = statisticQueryEntityRepository;
        UserSignInStatisticsOptions = userSignInStatisticsOptions;
        UserSignInEntityRepository = userSignInEntityRepository;
    }

    [HttpPost("user_statistics")]
    public async Task<Guid> CreateQuery( Guid userId, DateTime from, DateTime to)
    {
        var request = Request;
        return await StatisticQueryEntityRepository.Add(userId, from, to);
    }

    [HttpGet("info")]
    public async Task<QueryResultModel> GetStatistic([FromQuery] Guid queryId)
    {
        var query = await StatisticQueryEntityRepository.GetByIdAsync(queryId);

        var querySeconds = TimeSpan.FromTicks(DateTime.Now.Ticks - query.CreateAt.Ticks).TotalSeconds;
        var delaySeconds = UserSignInStatisticsOptions.CurrentValue.ResponseDelay.TotalSeconds;
        int percent = (int)(querySeconds / delaySeconds * 100);
        if (percent < 100)
        {
            return new QueryResultModel
            {
                QueryId = query.Id,
                Percent = percent
            };
        }
        else
        {
            var userSignIns = await UserSignInEntityRepository.GetUserSignInsByPeriodAsync(query.UserId, query.From, query.To);

            return new QueryResultModel
            {
                QueryId = query.Id,
                Percent = 100,
                UserStatistic = new UserStatisticResponse
                {
                    CountSignIn = userSignIns.Count,
                    UserId = query.UserId
                }
            };
        }

    }
}
