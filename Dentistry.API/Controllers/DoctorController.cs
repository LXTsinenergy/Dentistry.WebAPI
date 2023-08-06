﻿using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.ScheduleService;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class DoctorController : Controller
    {
        private readonly IDayService _dayService;
        private readonly INoteService _noteService;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService, INoteService noteService, IDayService dayService)
        {
            _doctorService = doctorService;
            _noteService = noteService;
            _dayService = dayService;
        }

        [HttpGet]
        public async Task<IActionResult> GetScheduleAsync(int doctorId, int dayId)
        {
            var day = await _dayService.GetDayByIdAsync(dayId);
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

            if (day != null && doctor != null)
            {
                var schedule = _noteService.GetDoctorSchedule(day, doctorId);
                if (schedule != null) return Ok(schedule);
            }
            return BadRequest();
        }
    }
}
