using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.DataContext
{
    public interface IApplicationDbContext
    {
        #region DbSets
        DbSet<User> Users { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Note> Notes { get; set; }
        DbSet<Speciality> Specialities { get; set; }
        DbSet<Workday> Days { get; set; }
        DbSet<Achievement> Achievements { get; set; }
        DbSet<Certificate> Certificates { get; set; }
        DbSet<Education> Educations { get; set; }
        DbSet<PlaceOfWork> PlacesOfWork { get; set; }
        DbSet<Review> Reviews { get; set; }
        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
