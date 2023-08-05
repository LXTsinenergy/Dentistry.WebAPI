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

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            try
            {
                var note = await _noteRepository.GetNoteByIdAsync(id);
                return note;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Note>> GetFreeNotesAsync()
        {
            try
            {
                var notes = await _noteRepository.GetNotesAsync();
                var freeNotes = notes
                    .Where(n => n.IsTaken == false);
                return freeNotes;
            }
            catch
            {
                return null;
            }
        }
    }
}
