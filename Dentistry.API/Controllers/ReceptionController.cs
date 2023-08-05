using Dentistry.BLL.Services.DoctorsNoteService;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class ReceptionController : Controller
    {
        private readonly INoteService _noteService;

        public ReceptionController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfNotesAsync()
        {
            var notes = await _noteService.GetNotesAsync();

            if (notes != null) return Ok(notes);
            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfUnacceptedNotesAsync()
        {
            var notes = await _noteService.GetUnacceptedNotesAsync();

            if (notes != null) return Ok(notes);
            return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> AcceptAppointmentNoteAsync(int id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);

            if (note != null)
            {
                if (note.IsTaken && !note.IsAccepted)
                {
                    var result =  await _noteService.ConfirmAppointmentNoteAsync(note);
                    if (result) return Ok();
                }
            }
            return BadRequest(id);
        }
    }
}
