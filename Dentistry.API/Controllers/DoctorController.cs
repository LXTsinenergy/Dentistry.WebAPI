using Dentistry.API.Models.Appointment;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById;
using Dentistry.BLL.CommandsAndQueries.Notes.Commands.ResetNote;
using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetDayDoctorNotes;
using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetDoctorNotes;
using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetNoteById;
using Dentistry.BLL.Models.Schedule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("doctor")]
    [Authorize(Roles = "admin, doctor")]
    public class DoctorController : BaseController
    {
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
            var getDoctorNotesQuery = new GetDoctorNotesQuery { Doctor = doctor };
            var notes = await Mediator.Send(getDoctorNotesQuery);
            return Ok(notes);
        }

        [Route("dayschedule")]
        [HttpGet]
        public async Task<IActionResult> GetDayScheduleAsync([FromQuery] GetDayScheduleDto getDayScheduleDto)
        {
            var getDoctorByIdQuery = new GetDoctorByIdQuery { Id = getDayScheduleDto.DoctorId };
            var doctor = await Mediator.Send(getDoctorByIdQuery);
            if (doctor == null)
            {
                return NotFound(getDayScheduleDto.DoctorId);
            }

            var getDayDoctorNotesQuery = new GetDayDoctorNotesQuery() { Doctor = doctor, Date = getDayScheduleDto.Date };
            var notes = await Mediator.Send(getDayDoctorNotesQuery);
            return Ok(notes);
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

            if (note == null)
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
