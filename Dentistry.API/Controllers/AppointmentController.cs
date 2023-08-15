using Dentistry.BLL.CommandsAndQueries.Notes.Queries;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("appointment")]
    [Authorize(Roles = "user, admin")]
    public class AppointmentController : BaseController
    {
        private readonly INoteService _noteService;
        private readonly IUserService _userService;

        public AppointmentController(INoteService noteService, IUserService userService)
        {
            _noteService = noteService;
            _userService = userService;
        }

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
        public async Task<IActionResult> SignUpForAppointmentAsync(int userId, int noteId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            var note = await _noteService.GetNoteByIdAsync(noteId);

            if (user != null && note != null)
            {
                if (!note.IsTaken)
                {
                    var result = await _noteService.BookAnAppointmentAsync(note, user);

                    if (result) return Ok();
                    return StatusCode(500);
                }
            }
            return NotFound();
        }
    }
}
