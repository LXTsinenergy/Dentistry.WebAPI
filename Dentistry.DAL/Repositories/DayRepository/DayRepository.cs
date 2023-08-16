using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.DayRepository
{
    public class DayRepository : IDayRepository
    {
        private readonly IApplicationDbContext _context;

        public DayRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workday>> GetAllAsync() =>
            await _context.Days
            .Include(d => d.Schedule)
            .ToListAsync();

        public async Task<Workday> GetByIdAsync(int id) =>
            await _context.Days
            .Include(d => d.Schedule)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Workday workday, CancellationToken cancellationToken)
        {
            await _context.Days.AddAsync(workday);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Workday workday, CancellationToken cancellationToken)
        {
            _context.Days.Remove(workday);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
