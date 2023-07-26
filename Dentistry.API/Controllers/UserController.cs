using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO.User;
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

            if (user != null)
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

            if (user != null)
            {
                var confirmationPasswordHash = _passwordService.HashPassword(confirmationPassword, user.Salt);

                if (confirmationPasswordHash != user.Password) return BadRequest(confirmationPassword);

                var result = await _userService.DeleteUserAsync(user);

                if (result) return Ok(result);
                return BadRequest(false);
            }
            return NotFound(id);
        }

        [HttpPut]
        public async Task<IActionResult> ChangeDataAsync(int id, UserUpdateDTO updateDTO)
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
    }
}
