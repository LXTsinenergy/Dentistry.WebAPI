using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorsNoteService
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            try
            {
                var notes = await _noteRepository.GetNotesAsync();
                return notes;
            }
            catch
            {
                return Enumerable.Empty<Note>();
            }
        }

        public async Task<IEnumerable<Note>> GetNotesByIdAsync(int id)
        {
            try
            {
                var notes = await _noteRepository.GetNotesByIdAsync(id);
                return notes;
            }
            catch
            {
                return null;
            }
        }
    }
}
