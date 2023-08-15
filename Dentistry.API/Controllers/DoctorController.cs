using Dentistry.BLL.CommandsAndQueries.Days.Queries;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries;
using Dentistry.BLL.Models.Schedule;
using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.ScheduleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("doctor")]
    [Authorize(Roles = "admin, doctor")]
    public class DoctorController : BaseController
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
        [Route("schedule")]
        [HttpGet]
        public async Task<IActionResult> GetGeneralScheduleAsync(int doctorId)
        {
            var getDoctorByIdQuery = new GetDoctorByIdQuery { Id = doctorId };
            var doctor = await Mediator.Send(getDoctorByIdQuery);

            if (doctor == null)
            {
                return NotFound(doctorId);
            }
            var schedule = _noteService.GetDoctorSchedule(doctor);
            return Ok(schedule);
        }

        [Route("dayschedule")]
        [HttpGet]
        public async Task<IActionResult> GetDayScheduleAsync([FromQuery] GetDayScheduleDto getDayScheduleDto)
        {
            var getDayByIdQuery = new GetDayByIdQuery { Id = getDayScheduleDto.DayId };
            var getDoctorByIdQuery = new GetDoctorByIdQuery { Id = getDayScheduleDto.DoctorId };

            var day = await Mediator.Send(getDayByIdQuery);
            var doctor = await Mediator.Send(getDoctorByIdQuery);

            if (day == null)
            {
                return NotFound(getDayScheduleDto.DayId);
            }
            if (doctor == null)
            {
                return NotFound(getDayScheduleDto.DoctorId);
            }
            var schedule = _noteService.GetDoctorDaySchedule(day, getDayScheduleDto.DoctorId);
            return Ok(schedule);
        }
        #endregion

        #region Appointment
        [Route("complete")]
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
