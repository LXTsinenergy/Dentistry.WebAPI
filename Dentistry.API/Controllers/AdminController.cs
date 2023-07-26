using Dentistry.BLL.Services.AccountService;
using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO.Doctor;
using Dentistry.Domain.DTO.DoctorDTO;
using Dentistry.Domain.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user != null) return Ok(user);
            return NotFound(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            if (await _userService.EmailIsRegistered(userDTO.Email) || await _userService.PhoneIsRegistered(userDTO.PhoneNumber))
            {
                return BadRequest(userDTO);
            }

            var salt = _passwordService.GenerateSalt();
            userDTO.Password = _passwordService.HashPassword(userDTO.Password, salt);

            var result = await _userService.AddNewUserAsync(userDTO, salt);

            if (result) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDTO updateDTO)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user != null)
            {
                if (await _userService.EmailIsRegistered(updateDTO.Email))
                {
                    return BadRequest(updateDTO.Email);
                }
                if (await _userService.PhoneIsRegistered(updateDTO.PhoneNumber))
                {
                    return BadRequest(updateDTO.PhoneNumber);
                }
                var result = await _userService.UpdateUserAsync(user, updateDTO);

                if (result) return Ok(result);
                return BadRequest(result);
            }
            return NotFound(id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user != null)
            {
                var result = await _userService.DeleteUserAsync(user);
                if (result) return Ok(result);
                return BadRequest(false);
            }
            return NotFound(id);
        }
        #endregion

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
        public async Task<IActionResult> AddDoctorAsync(DoctorCreationDTO creationDTO)
        {
            if (await _doctorService.PhoneIsRegistered(creationDTO.PhoneNumber) ||  await _doctorService.EmailIsRegistered(creationDTO.Email))
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
        public async Task<IActionResult> UpdateDoctor(int id, DoctorUpdateDTO updateDTO)
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
    }
}
