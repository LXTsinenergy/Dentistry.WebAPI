using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.ScheduleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "admin, doctor")]
    public class DoctorController : Controller
    {
        private readonly IDayService _dayService;
        private readonly INoteService _noteService;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService, INoteService noteService, IDayService dayService)
        {
            _doctorService = doctorService;
            _noteService = noteService;
            _dayService = dayService;
        }

        #region Schedule
        [HttpGet]
        public async Task<IActionResult> GetGeneralScheduleAsync(int doctorId)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

            if (doctor != null)
            {
                var schedule = _noteService.GetDoctorGeneralSchedule(doctor);

                if (schedule != null) return Ok(schedule);
                return StatusCode(500);
            }
            return NotFound(doctorId);
        }

        [HttpGet]
        public async Task<IActionResult> GetDayScheduleAsync(int doctorId, int dayId)
        {
            var day = await _dayService.GetDayByIdAsync(dayId);
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

            if (day != null && doctor != null)
            {
                var schedule = _noteService.GetDoctorDaySchedule(day, doctorId);

                if (schedule != null) return Ok(schedule);
                return StatusCode(500);
            }
            return NotFound();
        }
        #endregion

        #region Appointment
        [HttpPut]
        public async Task<IActionResult> CompleteAppointmentAsync(int noteId, int doctorId)
        {
            var note = await _noteService.GetNoteByIdAsync(noteId);
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

            if (note != null)
            {
                if (doctor.Notes.Contains(note) && _noteService.NoteIsTaken(note))
                {
                    var result = await _noteService.ResetNoteDataAsync(note);

                    if (result) return Ok(result);
                    return StatusCode(500);
                }
            }
            return NotFound();
        } 
        #endregion
    }
}
