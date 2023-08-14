using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.MessageService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.ReviewService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO.Review;
using Dentistry.Domain.DTO.User;
using Dentistry.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("user")]
    [Authorize(Roles = "user, admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly IMessageService _messageService;
        private readonly IReviewService _reviewService;
        private readonly IDoctorService _doctorService;
        private readonly CodeBuffer _buffer;

        public UserController(
            IUserService userService,
            IPasswordService passwordService,
            IMessageService messageService,
            IReviewService reviewService,
            IDoctorService doctorService,
            CodeBuffer buffer)
        {
            _userService = userService;
            _passwordService = passwordService;
            _messageService = messageService;
            _reviewService = reviewService;
            _doctorService = doctorService;
            _buffer = buffer;
        }

        [Route("password")]
        [HttpPut]
        public async Task<IActionResult> ChangePasswordAsync(string code, int id, string password)
        {
            if (code == _buffer.PasswordResetCode)
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user != null)
                {
                    var newPasswordHash = _passwordService.HashPassword(password, user.Salt);

                    var result = await _userService.UpdateUserPasswordAsync(user, newPasswordHash);

                    if (result)
                    {
                        _buffer.PasswordResetCode = string.Empty;
                        return Ok();
                    }
                    return StatusCode(500);
                }
                return NotFound(id);
            }
            return BadRequest(code);
        }

        [Route("code")]
        [HttpGet]
        public async Task<IActionResult> SendResetCodeAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user != null)
            {
                var code = _passwordService.GenerateCode();
                _buffer.PasswordResetCode = code;

                await _messageService.SendEmailAsync(user.Email, code);
                return Ok();
            }
            return NotFound(id);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccountAsync(int id, string confirmationPassword)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user != null)
            {
                var confirmationPasswordHash = _passwordService.HashPassword(confirmationPassword, user.Salt);

                if (confirmationPasswordHash != user.Password) return BadRequest(confirmationPassword);

                var result = await _userService.DeleteUserAsync(user);

                if (result) return Ok();
                return StatusCode(500);
            }
            return NotFound(id);
        }

        [Route("data")]
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

                if (result) return Ok();
                return StatusCode(500);
            }
            return NotFound(id);
        }

        [Route("review")]
        [HttpPost]
        public async Task<IActionResult> WriteCommentAsync(int userId, ReviewCreationDTO reviewCreationDTO)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            var doctor = await _doctorService.GetDoctorByIdAsync(reviewCreationDTO.DoctorId);

            if (user != null && doctor != null)
            {
                var result = await _reviewService.CreateReviewAsync(reviewCreationDTO, user.Fullname);

                if (result) return Ok(result);
                return StatusCode(500);
            }
            return NotFound();
        }
    }
}
