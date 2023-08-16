using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dentistry.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLL(
            this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
