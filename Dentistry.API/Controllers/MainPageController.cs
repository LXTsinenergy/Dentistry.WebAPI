using Dentistry.BLL.Services.DoctorService;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class MainPageController : Controller
    {
        private readonly IDoctorService _doctorService;

        public MainPageController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorsListAsync()
        {
            var doctors = await _doctorService.GetDoctorsAsync();

            if (doctors != null) return Ok(doctors);
            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorAsync(int doctorId)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

            if (doctor != null) return Ok(doctor);
            return NotFound(doctorId);
        }
    }
}
