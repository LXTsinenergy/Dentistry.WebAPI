using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetAllDoctors;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById;
using Dentistry.BLL.Services.DoctorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("/")]
    [Authorize(Roles = "admin, user, doctor, registrar, head")]
    public class MainPageController : BaseController
    {
        [Route("doctors")]
        [HttpGet]
        public async Task<IActionResult> GetDoctorsListAsync()
        {
            var getAllDoctorsQuery = new GetAllDoctorsQuery();
            var doctors = await Mediator.Send(getAllDoctorsQuery);
            return Ok(doctors);
        }

        [Route("doctor")]
        [HttpGet]
        public async Task<IActionResult> GetDoctorAsync(int id)
        {
            var getDoctorByIdQuery = new GetDoctorByIdQuery() { Id = id };
            var doctor = await Mediator.Send(getDoctorByIdQuery);

            if (doctor == null)
            {
                return NotFound(id);
            }
            return Ok(doctor);
        }
    }
}
