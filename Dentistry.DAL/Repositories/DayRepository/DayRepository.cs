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

        public async Task<IEnumerable<Workday>> GetAllDays() =>
            await _context.Days.ToListAsync();
    }
}
