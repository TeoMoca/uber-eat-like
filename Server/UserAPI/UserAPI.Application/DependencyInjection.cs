using Microsoft.Extensions.DependencyInjection;
using UserAPI.Application.CommandUseCase.Role;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.QueryUseCase.Role;
using UserAPI.Application.QueryUseCase.User;

namespace UserAPI.Application;

public static class DependencyInjection {
    
    public static void AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<QueryAllUsersHandler>();
        services.AddScoped<QueryAllRolesHandler>();
            
            
        services.AddScoped<CommandAddUserHandler>();
        services.AddScoped<CommandUpdateUserHandler>();
        services.AddScoped<CommandDeleteUserHandler>();
        services.AddScoped<CommandAddRoleHandler>();
        services.AddScoped<CommandDeleteRoleHandler>();
        services.AddScoped<CommandUpdateRoleHandler>();
    }    
}