using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.SpecialityRepository
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly IApplicationDbContext _context;

        public SpecialityRepository(IApplicationDbContext context) => 
            _context = context;

        public async Task<IEnumerable<Speciality>> GetAllAsync() =>
            await _context.Specialities.ToListAsync();

        public async Task<Speciality> GetByIdAsync(int id) =>
            await _context.Specialities
            .SingleOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Speciality speciality, CancellationToken cancellationToken)
        {
            await _context.Specialities.AddAsync(speciality);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Speciality speciality, CancellationToken cancellationToken)
        {
            _context.Specialities.Update(speciality);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Speciality speciality, CancellationToken cancellationToken)
        {
            _context.Specialities.Remove(speciality);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
