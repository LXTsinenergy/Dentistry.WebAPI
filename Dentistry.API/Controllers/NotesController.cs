using Dentistry.BLL.Services.DoctorsNoteService;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class NotesController : Controller
    {
        private readonly INoteService _notesService;

        public NotesController(INoteService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotesByIdAsync(int id)
        {
            var notes = await _notesService.GetNotesByIdAsync(id);

            if (notes != null) return Ok(notes);
            return StatusCode(500);
        }
    }
}
