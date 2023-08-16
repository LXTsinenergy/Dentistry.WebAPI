using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.NoteRepository
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllAsync();
        Task<Note> GetByIdAsync(int id);
        Task AddAsync(Note note, CancellationToken cancellationToken);
        Task UpdateAsync(Note note, CancellationToken cancellationToken);
        Task DeleteAsync(Note note, CancellationToken cancellationToken);
    }
}
