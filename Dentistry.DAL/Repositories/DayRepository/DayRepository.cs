using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.DayRepository
{
    public class DayRepository : IDayRepository
    {
        private readonly ApplicationDbContext _context;

        public DayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workday>> GetAllDaysAsync() =>
            await _context.Days.Include(d => d.Schedule).ToListAsync();

        public async Task<Workday> GetDayByIdAsync(int id) =>
            await _context.Days.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddNewDayAsync(Workday workday)
        {
            await _context.Days.AddAsync(workday);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDayAsync(Workday workday)
        {
            _context.Days.Remove(workday);
            await _context.SaveChangesAsync();
        }
    }
}
