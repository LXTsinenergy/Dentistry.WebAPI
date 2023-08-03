using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorsNoteService
{
    public interface IDoctorsNoteService
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<IEnumerable<Note>> GetNotesByIdAsync(int id);
    }
}
