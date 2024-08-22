using DataBase.Repositories.StatisticQuery;
using DataBase.Repositories.UserSignIn;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase.Repositories;

public static class ServiceExtensions
{
    public static IServiceCollection AddDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserSignInEntityRepository, UserSignInEntityRepository>();
        services.AddScoped<IStatisticQueryEntityRepository, StatisticQueryEntityRepository>();
        return services;
    }
}
