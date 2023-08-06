using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AppointmentController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IUserService _userService;

        public AppointmentController(INoteService noteService, IUserService userService)
        {
            _noteService = noteService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfFreeAppointmentsAsync()
        {
            var freeNotes = await _noteService.GetFreeNotesAsync();

            if (freeNotes != null) return Ok(freeNotes);
            return StatusCode(500);
        }

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
                }
                return BadRequest(noteId);
            }
            return BadRequest();
        }
    }
}
