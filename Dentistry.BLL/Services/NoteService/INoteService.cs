using Dentistry.BLL.Models.Note.DaySchedule;
using Dentistry.BLL.Models.Note.GeneralSchedule;
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
        DayScheduleVM GetDoctorDaySchedule(Workday workday, int doctorId);
        GeneralScheduleVM GetDoctorSchedule(Doctor doctor);

        Task<bool> CreateNoteAsync(NoteCreationDTO noteCreationDTO, int dayId, int doctorId);
        Task<bool> DeleteNoteAsync(Note note);

        Task<bool> BookAnAppointmentAsync(Note note, User user);
        Task<bool> ConfirmAppointmentAsync(Note note);
        Task<bool> ResetNoteDataAsync(Note note);
        bool NoteCanBeCompleted(Note note, Doctor doctor);
    }
}
