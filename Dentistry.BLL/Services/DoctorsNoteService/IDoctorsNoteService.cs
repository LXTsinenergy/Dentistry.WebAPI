using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorsNoteService
{
    public interface IDoctorsNoteService
    {
        Task<IEnumerable<DoctorsNote>> GetNotesAsync();
        Task<IEnumerable<DoctorsNote>> GetNotesByIdAsync(int id);
    }
}
