using Dentistry.DAL.DataContext;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.DAL.Repositories.ReviewRepository;
using Dentistry.DAL.Repositories.SpecialityRepository;
using Dentistry.DAL.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dentistry.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddScoped<IDayRepository, DayRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
