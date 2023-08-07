using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class ReceptionController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IDoctorService _doctorService;

        public ReceptionController(INoteService noteService, IDoctorService doctorService)
        {
            _noteService = noteService;
            _doctorService = doctorService;
        }

        #region GetNotes
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

        [HttpGet]
        public async Task<IActionResult> GetListOfUnacceptedDoctorNotesAsync(int doctorId)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

            if (doctor != null)
            {
                var notes = _noteService.GetUnacceptedDoctorNotes(doctor);

                if (notes != null) return Ok(notes);
                return StatusCode(500);
            }
            return NotFound(doctorId);
        }
        #endregion

        #region Accept
        [HttpPut]
        public async Task<IActionResult> AcceptAppointmentNoteAsync(int id, string procedureName)
        {
            var note = await _noteService.GetNoteByIdAsync(id);

            if (note != null)
            {
                if (note.IsTaken && !note.IsAccepted)
                {
                    note.ProcedureName = procedureName;
                    var result = await _noteService.ConfirmAppointmentAsync(note);
                    if (result) return Ok();
                }
            }
            return BadRequest(id);
        } 
        #endregion
    }
}
