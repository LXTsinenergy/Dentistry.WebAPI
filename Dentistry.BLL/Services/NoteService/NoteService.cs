using AutoMapper;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.Domain.DTO.Note;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorsNoteService
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        #region Get
        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            try
            {
                var notes = await _noteRepository.GetAllAsync();
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
                var note = await _noteRepository.GetByIdAsync(id);
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
                var notes = await _noteRepository.GetAllAsync();
                var freeNotes = notes
                    .Where(n => n.IsTaken == false);
                return freeNotes;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Note>> GetUnacceptedNotesAsync()
        {
            try
            {
                var notes = await _noteRepository.GetAllAsync();
                var unacceptedNotes = notes
                    .Where(n => !n.IsAccepted)
                    .Where(n => n.IsTaken);
                return unacceptedNotes;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Note> GetUnacceptedDoctorNotes(Doctor doctor)
        {
            try
            {
                var notes = doctor.Notes
                    .Where(x => x.IsTaken)
                    .Where(x => !x.IsAccepted);
                return notes;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Note> GetDoctorGeneralSchedule(Doctor doctor)
        {
            var notes = doctor.Notes
                .Where(x => x.IsTaken)
                .Where(x => x.IsAccepted);
            return notes;
        }

        public IEnumerable<Note> GetDoctorDaySchedule(Workday workday, int doctorId)
        {
            var notes = workday.Schedule
                .Where(x => x.DoctorId == doctorId)
                .Where(x => x.IsTaken)
                .Where(x => x.IsAccepted);
            return notes;
        }
        #endregion

        #region Note operations
        public async Task<bool> CreateNoteAsync(NoteCreationDTO noteCreationDTO, int dayId, int doctorId)
        {
            try
            {
                var note = _mapper.Map<Note>(noteCreationDTO);
                note.DoctorId = doctorId;
                note.WorkdayId = dayId;

                await _noteRepository.AddAsync(note);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteNoteAsync(Note note)
        {
            try
            {
                await _noteRepository.DeleteAsync(note);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> BookAnAppointmentAsync(Note note, User user)
        {
            try
            {
                note.PatientFullname = user.Name;
                note.PatientPhoneNumber = user.PhoneNumber;
                note.PatientEmail = user.Email;
                note.IsTaken = true;

                await _noteRepository.UpdateAsync(note);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ConfirmAppointmentAsync(Note note)
        {
            try
            {
                note.IsAccepted = true;
                await _noteRepository.UpdateAsync(note);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ResetNoteDataAsync(Note note)
        {
            try
            {
                note = ResetNoteData(note);
                await _noteRepository.UpdateAsync(note);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Note ResetNoteData(Note note)
        {
            note.IsTaken = false;
            note.IsAccepted = false;
            note.Comment = "";
            note.PatientFullname = "";
            note.PatientPhoneNumber = "";
            note.PatientEmail = "";
            note.ProcedureName = "";

            return note;
        }

        public bool NoteIsTaken(Note note)
        {
            if (note.IsAccepted && note.IsTaken) return true;
            return false;
        } 
        #endregion
    }
}
