using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.NoteRepository
{
    public class NoteRepository : INoteRepository
    {
        private readonly IApplicationDbContext _context;

        public NoteRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetAllAsync() =>
            await _context.Notes
            .ToListAsync();

        public async Task<Note> GetByIdAsync(int id) =>
            await _context.Notes
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Note note, CancellationToken cancellationToken)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Note note, CancellationToken cancellationToken)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Note note, CancellationToken cancellationToken)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
