using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.ScheduleService;
using Dentistry.Domain.DTO.Doctor;
using Dentistry.Domain.DTO.DoctorDTO;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class HeadPhysicianController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPasswordService _passwordService;
        private readonly IScheduleService _scheduleService;

        public HeadPhysicianController(
            IDoctorService doctorService,
            IPasswordService passwordService,
            IScheduleService scheduleService)
        {
            _doctorService = doctorService;
            _passwordService = passwordService;
            _scheduleService = scheduleService;
        }

        #region Doctor
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var doctors = await _doctorService.GetAllAsync();

            if (doctors != null) return Ok(doctors);
            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor != null) return Ok(doctor);
            return NotFound(id);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewDoctorAsync(DoctorCreationDTO creationDTO)
        {
            if (await _doctorService.PhoneIsRegistered(creationDTO.PhoneNumber) || await _doctorService.EmailIsRegistered(creationDTO.Email))
            {
                return BadRequest(creationDTO);
            }

            var salt = _passwordService.GenerateSalt();
            creationDTO.Password = _passwordService.HashPassword(creationDTO.Password, salt);

            var result = await _doctorService.AddNewDoctorAsync(creationDTO, salt);

            if (result) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorDataAsync(int id, DoctorUpdateDTO updateDTO)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor != null)
            {
                if (await _doctorService.EmailIsRegistered(updateDTO.Email))
                {
                    return BadRequest(updateDTO.Email);
                }
                if (await _doctorService.PhoneIsRegistered(updateDTO.PhoneNumber))
                {
                    return BadRequest(updateDTO.PhoneNumber);
                }
                var result = await _doctorService.UpdateDoctorAsync(doctor, updateDTO);

                if (result) return Ok(result);
                return BadRequest(result);
            }
            return NotFound(id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor != null)
            {
                var result = await _doctorService.DeleteDoctorAsync(doctor);
                if (result) return Ok(result);
                return BadRequest(false);
            }
            return NotFound(id);
        }
        #endregion

        #region Schedule
        [HttpPost]
        public async Task<IActionResult> GetGeneralScheduleAsync()
        {
            var schedule = await _scheduleService.GetAllDays();
            return Ok(schedule);
        }
        #endregion
    }
}
