using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public static class UserStatisticsDbContextExtensions
{
    public static IServiceCollection AddUserStatisticsDbContext(
        this IServiceCollection services, 
        string connectionString = "Data Source=PC-ZET;Initial Catalog=test5566;Integrated Security=True;Encrypt=False"
    )
    {
        services.AddDbContext<UserStatisticDbContext>(opions => opions.UseSqlServer(connectionString), ServiceLifetime.Transient);
        return services;
    }
}
