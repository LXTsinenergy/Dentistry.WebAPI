using AutoMapper;
using Dentistry.API.Models.Appointment;
using Dentistry.BLL.CommandsAndQueries.Notes.Commands.BookAppointment;
using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetFreeNotes;
using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetNoteById;
using Dentistry.BLL.CommandsAndQueries.Users.Queries.GetUserById;
using Dentistry.BLL.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("appointment")]
    [Authorize(Roles = "user, admin")]
    public class AppointmentController : BaseController
    {
        private readonly IMapper _mapper;

        public AppointmentController(IMapper mapper) => _mapper = mapper;

        [Route("appointments")]
        [HttpGet]
        public async Task<IActionResult> GetListOfFreeAppointmentsAsync()
        {
            var getFreeNotesQuery = new GetFreeNotesQuery();
            var freeNotes = await Mediator.Send(getFreeNotesQuery);
            return Ok(freeNotes);
        }

        [Route("registration")]
        [HttpPost]
        public async Task<IActionResult> SignUpForAppointmentAsync([FromQuery] SignUpDto signUpDto)
        {
            var getUserByIdQuery = new GetUserByIdQuery { Id = signUpDto.UserId };
            var getNoteByIdQery = new GetNoteByIdQuery { Id = signUpDto.NoteId };

            var user = await Mediator.Send(getUserByIdQuery);
            var note = await Mediator.Send(getNoteByIdQery);

            if (user == null)
            {
                return NotFound(signUpDto.UserId);
            }
            if (note == null || note.IsTaken)
            {
                return NotFound(signUpDto.NoteId);
            }

            var userAppointmentDto = _mapper.Map<UserAppointmentDto>(user);
            var bookAppointmentCommand = new BookAppointmentCommand 
            { 
                UserAppointmentDto = userAppointmentDto,
                Note = note
            };
            var result = await Mediator.Send(bookAppointmentCommand);
            return Ok(result);
        }
    }
}
