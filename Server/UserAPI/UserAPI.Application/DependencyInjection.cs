using Microsoft.Extensions.DependencyInjection;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.QueryUseCase.User;

namespace UserAPI.Application;

public static class DependencyInjection {
    
    public static void AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<QueryAllUsersHandler>();
        services.AddScoped<CommandAddUserHandler>();
        services.AddScoped<CommandUpdateUserHandler>();
        services.AddScoped<CommandDeleteUserHandler>();
    }    
}