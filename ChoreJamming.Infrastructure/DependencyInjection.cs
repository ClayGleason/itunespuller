using ChoreJamming.Domain;
using ChoreJamming.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChoreJamming.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConn)
    {
        services.AddDbContext<ChoreDbContext>(o => o.UseSqlite(dbConn));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddHttpClient<IMusicProvider, AudioDbService>();
        return services;
    }
}