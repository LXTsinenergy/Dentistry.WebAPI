using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.DoctorsNoteRepository
{
    public class DoctorsNoteRepository : IDoctorsNoteRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorsNoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetNotesAsync() =>
            await _context.Notes.ToListAsync();

        public async Task<IEnumerable<Note>> GetNotesByIdAsync(int id) => 
            await _context.Notes.Where(n => n.Id == id).ToListAsync();
    }
}
