using AutoMapper;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.DAL.Repositories.DoctorRepository;
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

        public async Task<IEnumerable<Note>> GetUnacceptedNotesAsync()
        {
            try
            {
                var notes = await _noteRepository.GetNotesAsync();
                var unacceptedNotes = notes
                    .Where(n => n.IsAccepted == false);
                return unacceptedNotes;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateNoteAsync(NoteCreationDTO noteCreationDTO, int dayId, int doctorId)
        {
            try
            {
                var note = _mapper.Map<Note>(noteCreationDTO);
                note.DoctorId = doctorId;
                note.WorkdayId = dayId;
                note.Comment = "";
                note.PatientFullname = "";


                await _noteRepository.CreateNoteAsync(note);
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

                await _noteRepository.UpdateNoteAsync(note);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ConfirmAppointmentNoteAsync(Note note)
        {
            try
            {
                note.IsAccepted = true;
                await _noteRepository.UpdateNoteAsync(note);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
