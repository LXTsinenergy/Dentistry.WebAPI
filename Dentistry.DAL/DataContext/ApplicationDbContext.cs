using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorsNote> DoctorsNotes { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Doctor Table

            modelBuilder.Entity<Doctor>().OwnsOne(x => x.Specialties);
            modelBuilder.Entity<Doctor>().OwnsOne(x => x.PlacesOfWork);
            modelBuilder.Entity<Doctor>().OwnsOne(x => x.Education);
            modelBuilder.Entity<Doctor>().OwnsOne(x => x.Achievements);
            modelBuilder.Entity<Doctor>().OwnsOne(x => x.Certificates);
            modelBuilder.Entity<Doctor>().OwnsOne(x => x.Reviews);

            #endregion
        }
    }
}
