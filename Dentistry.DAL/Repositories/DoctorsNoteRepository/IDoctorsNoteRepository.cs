using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DoctorsNoteRepository
{
    public interface IDoctorsNoteRepository
    {
        Task<IEnumerable<DoctorsNote>> GetNotesAsync();
        Task<IEnumerable<DoctorsNote>> GetNotesByIdAsync(int id);
    }
}
