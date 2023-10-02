using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetAllNotes;
using Dentistry.BLL.Services.DoctorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("reception")]
    [Authorize(Roles = "registrar, admin")]
    public class ReceptionController : BaseController
    {
        private readonly IDoctorService _doctorService;

        public ReceptionController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        #region GetNotes
        [Route("notes")]
        [HttpGet]
        public async Task<IActionResult> GetNotesAsync()
        {
            var getAllNotesQuery = new GetAllNotesQuery();
            var notes = await Mediator.Send(getAllNotesQuery);
            return Ok(notes);
        }

        [Route("unacceptednotes")]
        [HttpGet]
        public async Task<IActionResult> GetListOfUnacceptedNotesAsync()
        {
            //var notes = await _noteService.GetUnacceptedNotesAsync();

            return Ok();
        }

        [Route("doctornotes/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetListOfUnacceptedDoctorNotesAsync(int doctorId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Accept
        [Route("confirmation/{id:int}")]
        [HttpPut]
        public async Task<IActionResult> AcceptAppointmentAsync(int id, string procedureName)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
