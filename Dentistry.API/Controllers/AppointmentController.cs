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
        private readonly IDoctorService _doctorService;

        public AppointmentController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUpForAppointmentAsync(int userId, int doctorId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

            if (user != null && doctor != null)
            {
                throw new NotImplementedException();
            }
            return BadRequest();
        }
    }
}
