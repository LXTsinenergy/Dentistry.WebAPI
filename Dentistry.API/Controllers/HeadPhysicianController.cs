using AutoMapper;
using Dentistry.API.Models.Doctor;
using Dentistry.API.Models.Speciality;
using Dentistry.BLL.CommandsAndQueries.Days.Queries.GetAllDays;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.CreateDoctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.DeleteDoctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.UpdateDoctor;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetAllDoctors;
using Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById;
using Dentistry.BLL.CommandsAndQueries.Notes.Commands.CreateNote;
using Dentistry.BLL.CommandsAndQueries.Notes.Commands.DeleteNote;
using Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetNoteById;
using Dentistry.BLL.CommandsAndQueries.Specialties.Commands.CreateSpeciality;
using Dentistry.BLL.CommandsAndQueries.Specialties.Queries.GetSpecialties;
using Dentistry.BLL.Models.Doctor.DoctorById;
using Dentistry.BLL.Models.Note.CreateNote;
using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.ScheduleService;
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
            var getAllDaysQuery = new GetAllDaysQuery();
            var schedule = await Mediator.Send(getAllDaysQuery);
            return Ok(schedule);
        }
        #endregion

        #region Notes
        [Route("newnote")]
        [HttpPost]
        public async Task<IActionResult> CreateNoteAsync([FromBody] CreateNoteDto createNoteDto)
        {
            var createNoteCommand = _mapper.Map<CreateNoteCommand>(createNoteDto);
            var result = await Mediator.Send(createNoteCommand);
            return Ok(result);
        }

        [Route("deletenote")]
        [HttpDelete]
        public async Task<IActionResult> DeleteNoteAsync(int id)
        {
            var getNoteByIdQuery = new GetNoteByIdQuery { Id = id };
            var note = await Mediator.Send(getNoteByIdQuery);

            if (note == null)
            {
                return NotFound(id);
            }
            var deleteNoteCommand = new DeleteNoteCommand { Note = note };
            var result = await Mediator.Send(deleteNoteCommand);
            return Ok(result);
        }
        #endregion
    }
}
