using DataBase;
using DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TestTaskVitaliyPonomarev;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddUserStatisticsDbContext();

builder.Services.AddDbRepositories();

builder.Services.Configure<UserSignInStatisticsOptions>(builder.Configuration.GetSection(nameof(UserSignInStatisticsOptions)));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
