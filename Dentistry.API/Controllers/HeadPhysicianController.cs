using AutoMapper;
using Dentistry.API.Models.Doctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.CreateDoctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetAllDoctors;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById;
using Dentistry.BLL.Helpers;
using Dentistry.BLL.Models.Doctor.DoctorById;
using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.ScheduleService;
using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.DTO.Doctor;
using Dentistry.Domain.DTO.DoctorDTO;
using Dentistry.Domain.DTO.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("headphysician")]
    [Authorize(Roles = "admin, head")]
    public class HeadPhysicianController : BaseController
    {
        private readonly IDoctorService _doctorService;
        private readonly IDayService _dayService;
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public HeadPhysicianController(
            IDoctorService doctorService,
            IDayService dayService,
            INoteService noteService,
            IMapper mapper)
        {
            _doctorService = doctorService;
            _dayService = dayService;
            _noteService = noteService;
            _mapper = mapper;
        }

        #region Doctor
        [HttpGet]
        [Route("doctors")]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var getAllDoctorsQuery = new GetAllDoctorsQuery();
            var doctors = await Mediator.Send(getAllDoctorsQuery);
            return Ok(doctors);
        }

        [Route("doctor")]
        [HttpGet]
        public async Task<IActionResult> GetDoctorByIdAsync([FromQuery] int id)
        {
            var getDoctorByIdQuery = new GetDoctorByIdQuery { Id = id };
            var doctor = await Mediator.Send(getDoctorByIdQuery);

            if (doctor == null)
            {
                return NotFound(id);
            }
            var doctorVm = _mapper.Map<DoctorByIdVM>(doctor);
            return Ok(doctorVm);
        }

        [Route("newdoctor")]
        [HttpPost]
        public async Task<IActionResult> RegisterNewDoctorAsync([FromBody] DoctorCreationDto creationDTO)
        {
            var createDoctorCommand = _mapper.Map<CreateDoctorCommand>(creationDTO);
            var result = await Mediator.Send(createDoctorCommand);
            return Ok(result);
        }

        [Route("updatedoctor/{id:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDoctorDataAsync(int id, DoctorUpdateDTO updateDTO)
        {
            // Новая таблица под специальности
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

        [Route("deletedoctor/{id:int}")]
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
        [Route("schedule")]
        [HttpGet]
        public async Task<IActionResult> GetGeneralScheduleAsync()
        {
            var schedule = await _dayService.GetAllDaysAsync();

            if (schedule != null) return Ok(schedule);
            return StatusCode(500);
        }

        [Route("newday")]
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

        [Route("deleteday")]
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
        [Route("addnotetodoctor")]
        [HttpGet]
        public async Task<IActionResult> AddNoteToDoctorScheduleAsync(NoteCreationDTO noteCreationDTO, int dayId, int doctorId)
        {
            var result = await _noteService.CreateNoteAsync(noteCreationDTO, dayId, doctorId);

            if (result) return Ok();
            return BadRequest();
        }

        [Route("deletenote/{id:int}")]
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
