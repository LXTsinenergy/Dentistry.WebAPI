using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("/admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllAsync();

            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            var user = await _userService.AddAsync(userDTO);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(userDTO);
            }
        }
    }
}
