using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.NoteRepository
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetNotesAsync() =>
            await _context.Notes.ToListAsync();

        public async Task<IEnumerable<Note>> GetNotesByIdAsync(int id) => 
            await _context.Notes.Where(n => n.Id == id).ToListAsync();
    }
}
