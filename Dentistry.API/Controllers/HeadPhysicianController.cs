using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.ScheduleService;
using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.DTO.Doctor;
using Dentistry.Domain.DTO.DoctorDTO;
using Dentistry.Domain.DTO.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "admin, head")]
    public class HeadPhysicianController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPasswordService _passwordService;
        private readonly IDayService _dayService;
        private readonly INoteService _noteService;

        public HeadPhysicianController(
            IDoctorService doctorService,
            IPasswordService passwordService,
            IDayService dayService,
            INoteService noteService)
        {
            _doctorService = doctorService;
            _passwordService = passwordService;
            _dayService = dayService;
            _noteService = noteService;
        }

        #region Doctor
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var doctors = await _doctorService.GetDoctorsAsync();

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

            var result = await _doctorService.CreateDoctorAsync(creationDTO, salt);

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

        #region Workdays
        [HttpGet]
        public async Task<IActionResult> GetGeneralScheduleAsync()
        {
            var schedule = await _dayService.GetAllDaysAsync();

            if (schedule != null) return Ok(schedule);
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewWorkdayAsync(WorkdayCreationDTO creationDTO)
        {
            var coincidingDays = await _dayService.GetCoincidingDaysAsync(creationDTO.DayOfWeek);

            if (coincidingDays.ToList().Count == 0)
            {
                var result = await _dayService.CreateDayAsync(creationDTO);
                if (result) return Ok();
            }
            return BadRequest(creationDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkdayAsync(int id)
        {
            var day = await _dayService.GetDayByIdAsync(id);

            if (day != null)
            {
                var result = await _dayService.DeleteDayAsync(day);

                if (result) return Ok();
                return StatusCode(500);
            }
            return NotFound(id);
        }
        #endregion

        #region Notes
        [HttpGet]
        public async Task<IActionResult> AddNoteToDoctorScheduleAsync(NoteCreationDTO noteCreationDTO, int dayId, int doctorId)
        {
            var result = await _noteService.CreateNoteAsync(noteCreationDTO, dayId, doctorId);

            if (result) return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNoteAsync(int id)
        {
            var note = await _noteService.GetNoteByIdAsync(id);

            if (note != null)
            {
                var result = await _noteService.DeleteNoteAsync(note);

                if (result) return Ok();
                return StatusCode(500);
            }
            return NotFound(id);
        }
        #endregion
    }
}
