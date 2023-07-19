using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO;
using Dentistry.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;
        private readonly IPasswordService _passwordService;

        public AdminController(IUserService userService,
            IDoctorService doctorService,
            IPasswordService passwordService)
        {
            _userService = userService;
            _doctorService = doctorService;
            _passwordService = passwordService;
        }

        #region User
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllAsync();

            if (users != null) return Ok(users);

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            if (await UserIsExists(userDTO)) return BadRequest(userDTO);

            var salt = _passwordService.GenerateSalt();
            userDTO.Password = _passwordService.HashPassword(userDTO.Password, salt);

            var user = await _userService.AddNewUserAsync(userDTO, salt);

            return Ok(user);
        }

        private async Task<bool> UserIsExists(UserDTO userDTO)
        {
            var possibleUserByPhone = await _userService.GetUserByEmailAsync(userDTO.Email);
            var possibleUserByEmail = await _userService.GetUserByPhoneNumberAsync(userDTO.PhoneNumber);

            if (possibleUserByPhone != null || possibleUserByEmail != null) return true;
            return false;
        }
        #endregion

        #region Doctor
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var doctors = await _doctorService.GetAllAsync();

            if (doctors != null) return Ok(doctors);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorAsync([FromBody]DoctorDTO doctorDTO)
        {
            if (await DoctorIsExists(doctorDTO)) return BadRequest(doctorDTO);

            var salt = _passwordService.GenerateSalt();
            doctorDTO.Password = _passwordService.HashPassword(doctorDTO.Password, salt);

            var doctor = await _doctorService.AddNewDoctorAsync(doctorDTO, salt);
            
            return Ok(doctor);
        }

        private async Task<bool> DoctorIsExists(DoctorDTO doctorDTO)
        {
            var possibleDoctorByPhone = await _doctorService.GetDoctorByEmailAsync(doctorDTO.Email);
            var possibleDoctorrByEmail = await _doctorService.GetDoctorPhoneNumberAsync(doctorDTO.PhoneNumber);

            if (possibleDoctorrByEmail != null || possibleDoctorByPhone != null) return true;
            return false;
        }
        #endregion
    }
}
