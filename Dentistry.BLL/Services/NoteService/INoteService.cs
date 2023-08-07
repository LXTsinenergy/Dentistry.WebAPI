using Dentistry.Domain.DTO.Note;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorsNoteService
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> GetNoteByIdAsync(int id);
        Task<IEnumerable<Note>> GetFreeNotesAsync();
        Task<IEnumerable<Note>> GetUnacceptedNotesAsync();
        IEnumerable<Note> GetUnacceptedDoctorNotes(Doctor doctor);
        IEnumerable<Note> GetDoctorDaySchedule(Workday workday, int doctorId);
        IEnumerable<Note> GetDoctorGeneralSchedule(Doctor doctor);

        Task<bool> CreateNoteAsync(NoteCreationDTO noteCreationDTO, int dayId, int doctorId);
        Task<bool> DeleteNoteAsync(Note note);

        Task<bool> BookAnAppointmentAsync(Note note, User user);
        Task<bool> ConfirmAppointmentAsync(Note note);
        Task<bool> ResetNoteDataAsync(Note note);
        bool NoteIsTaken(Note note);
    }
}
