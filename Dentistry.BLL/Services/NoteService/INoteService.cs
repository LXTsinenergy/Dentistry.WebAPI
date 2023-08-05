using Dentistry.Domain.DTO.Note;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorsNoteService
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> GetNoteByIdAsync(int id);
        Task<IEnumerable<Note>> GetFreeNotesAsync();
        Task<bool> CreateNoteAsync(NoteCreationDTO noteCreationDTO, int dayId, int doctorId);
    }
}
