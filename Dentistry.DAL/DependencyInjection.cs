using Dentistry.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dentistry.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
