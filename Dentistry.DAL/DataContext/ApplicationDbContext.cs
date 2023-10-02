using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.DataContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<PlaceOfWork> PlacesOfWork { get; set; }
        public DbSet<Review> Reviews { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
