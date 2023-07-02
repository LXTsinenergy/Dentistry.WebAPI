using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public AdminController(IUserService userService,
            IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

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
            var salt = _passwordService.GenerateSalt();
            userDTO.Password = _passwordService.HashPassword(userDTO.Password, salt);

            var user = await _userService.AddNewUserAsync(userDTO, salt);

            return Ok(user);
        }
    }
}
