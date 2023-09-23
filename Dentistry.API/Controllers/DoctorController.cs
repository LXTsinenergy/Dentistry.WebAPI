using Dentistry.API.Models.Appointment;
using Dentistry.BLL.CommandsAndQueries.Days.Queries;
using Dentistry.BLL.CommandsAndQueries.Days.Queries.GetDayById;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById;
using Dentistry.BLL.CommandsAndQueries.Notes.Commands.ResetNote;
using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetNoteById;
using Dentistry.BLL.Models.Schedule;
using Dentistry.BLL.Services.DoctorsNoteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("doctor")]
    [Authorize(Roles = "admin, doctor")]
    public class DoctorController : BaseController
    {
        private readonly INoteService _noteService;

        public DoctorController(INoteService noteService) => _noteService = noteService;

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
        public async Task<IActionResult> CompleteAppointmentAsync([FromQuery] CompleteAppointmentDto appointmentDto)
        {
            var getNoteByIdQuery = new GetNoteByIdQuery { Id = appointmentDto.NoteId };
            var getDoctorByIdQuery = new GetDoctorByIdQuery { Id = appointmentDto.DoctorId };

            var note = await Mediator.Send(getNoteByIdQuery);
            var doctor = await Mediator.Send(getDoctorByIdQuery);

            if (note == null || !_noteService.NoteCanBeCompleted(note, doctor))
            {
                return NotFound(appointmentDto.NoteId);
            }
            if (doctor == null)
            {
                return NotFound(appointmentDto.DoctorId);
            }

            var resetNoteCommand = new ResetNoteCommand { Note = note };
            var result = await Mediator.Send(resetNoteCommand);
            return Ok(result);
        } 
        #endregion
    }
}
