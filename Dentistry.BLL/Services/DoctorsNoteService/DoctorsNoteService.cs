using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.DoctorsNoteRepository;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorsNoteService
{
    public class DoctorsNoteService : IDoctorsNoteService
    {
        private readonly IDoctorsNoteRepository _noteRepository;

        public DoctorsNoteService(IDoctorsNoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<DoctorsNote>> GetNotesAsync()
        {
            try
            {
                var notes = await _noteRepository.GetNotesAsync();
                return notes;
            }
            catch
            {
                return Enumerable.Empty<DoctorsNote>();
            }
        }

        public async Task<IEnumerable<DoctorsNote>> GetNotesByIdAsync(int id)
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
