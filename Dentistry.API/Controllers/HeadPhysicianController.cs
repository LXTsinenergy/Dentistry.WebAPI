using AutoMapper;
using Dentistry.API.Models.Doctor;
using Dentistry.API.Models.Speciality;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.CreateDoctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.DeleteDoctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.UpdateDoctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetAllDoctors;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById;
using Dentistry.BLL.CommandsAndQueries.Specialties.Commands.CreateSpeciality;
using Dentistry.BLL.CommandsAndQueries.Specialties.Queries.GetSpecialties;
using Dentistry.BLL.Models.Doctor.DoctorById;
using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.ScheduleService;
using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.DTO.Doctor;
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
            var doctorVM = _mapper.Map<DoctorByIdVM>(doctor);
            return Ok(doctorVM);
        }

        [Route("newdoctor")]
        [HttpPost]
        public async Task<IActionResult> RegisterNewDoctorAsync([FromBody] DoctorCreateDto creationDTO)
        {
            var createDoctorCommand = _mapper.Map<CreateDoctorCommand>(creationDTO);
            var result = await Mediator.Send(createDoctorCommand);
            return Ok(result);
        }

        [Route("updatedoctor")]
        [HttpPut]
        public async Task<IActionResult> UpdateDoctorDataAsync(DoctorUpdateDto updateDto)
        {
            var getDoctorByIdQuery = new GetDoctorByIdQuery { Id = updateDto.Id };
            var doctor = await Mediator.Send(getDoctorByIdQuery);

            if (doctor == null)
            {
                return NotFound(updateDto.Id);
            }

            var updateDoctorCommand = _mapper.Map<UpdateDoctorCommand>(updateDto);
            updateDoctorCommand.Doctor = doctor;
            var result = await Mediator.Send(updateDoctorCommand);
            return Ok(result);
        }

        [Route("deletedoctor")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctorAsync(int id)
        {
            var getDoctorByIdQuery = new GetDoctorByIdQuery { Id = id };
            var doctor = await Mediator.Send(getDoctorByIdQuery);

            if (doctor == null)
            {
                return NotFound(id);
            }
            var deleteDoctorCommand = new DeleteDoctorCommand { Doctor = doctor };
            var result = await Mediator.Send(deleteDoctorCommand);
            return Ok(result);
        }
        #endregion

        [Route("specialties")]
        [HttpGet]
        public async Task<IActionResult> GetSpecialtiesAsync()
        {
            var getAllSpecialtiesQuery = new GetAllSpecialtiesQuery();
            var result = await Mediator.Send(getAllSpecialtiesQuery);
            return Ok(result);
        }

        [Route("newspeciality")]
        [HttpPost]
        public async Task<IActionResult> AddSpecialityAsync([FromBody] SpecialityCreateDto createDto)
        {
            var createSpecialityCommand = _mapper.Map<CreateSpecialityCommand>(createDto);
            var result = await Mediator.Send(createSpecialityCommand);
            return Ok(result);
        }

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
