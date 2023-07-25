using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public UserController(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpPut]
        public async Task<IActionResult> ChangePasswordAsync(int id, string password)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (await _userService.UserIsExists(user))
            {
                var newPasswordHash = _passwordService.HashPassword(password, user.Salt);

                var result = await _userService.UpdateUserPasswordAsync(user, newPasswordHash);

                if (result) return Ok();
                return StatusCode(500);
            }
            return NotFound(id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccountAsync(int id, string confirmationPassword)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (await _userService.UserIsExists(user))
            {
                var confirmationPasswordHash = _passwordService.HashPassword(confirmationPassword, user.Salt);

                if (confirmationPasswordHash != user.Password) return BadRequest(confirmationPassword);

                var result = await _userService.DeleteUserAsync(user);
                if (result) return Ok(result);
                return BadRequest(false);
            }
            return NotFound(id);
        }
    }
}
