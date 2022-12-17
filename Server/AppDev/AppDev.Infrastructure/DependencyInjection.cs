using AppDev.Applications.Interface;
using AppDev.Infrastructure.Repository;

namespace AppDev.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
            
    }
}