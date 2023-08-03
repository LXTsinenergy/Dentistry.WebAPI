using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DoctorsNoteRepository
{
    public interface IDoctorsNoteRepository
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<IEnumerable<Note>> GetNotesByIdAsync(int id);
    }
}
