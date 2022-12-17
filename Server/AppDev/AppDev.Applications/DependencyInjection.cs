using AppDev.Applications.CommandUseCase.User;
using AppDev.Applications.QueryUseCase.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev.Applications
{
    public static class DependencyInjection
    {
        public static void AddUseCase(this IServiceCollection services)
        {
            services.AddScoped<QueryAllUserHandler>();

            services.AddScoped<CommandAddUserHandler>();
        }
    }
}
