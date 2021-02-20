using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceEntentions
    {
        public static IServiceCollection AddapplicationServices(this IServiceCollection services,
                                                                IConfiguration _config)  
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>{
                options.UseSqlite(_config.GetConnectionString("DefaultDb"));
            });
            return services;
        }
        
    }
}