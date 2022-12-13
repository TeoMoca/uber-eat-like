using Microsoft.Extensions.DependencyInjection;
using UserAPI.Application.Interface;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure;

public static class DependencyInjection {
    
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}