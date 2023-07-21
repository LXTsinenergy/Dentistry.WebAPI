using Dentistry.BLL.Services.ClaimsService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IClaimsService _claimsService;
        private readonly IPasswordService _passwordService;

        public AccountController(IUserService userService,
            IClaimsService claimsService,
            IPasswordService passwordService)
        {
            _userService = userService;
            _claimsService = claimsService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDTO loginDTO)
        {
            var user = await _userService.GetUserByEmailAsync(loginDTO.Email);

            if (user == null) return NotFound();
            if (user.Password != _passwordService.HashPassword(loginDTO.Password, user.Salt))
            {
                return BadRequest(loginDTO.Password);
            }

            var claimsPrincipal = _claimsService.CreateClaimsPrincipal(user);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            
            return Ok(loginDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDTO registerDTO)
        {
            var possibleUser = await _userService.GetUserByEmailAsync(registerDTO.Email);

            if (possibleUser != null) return BadRequest(registerDTO);

            if (registerDTO.Password == registerDTO.ConfirmedPassword)
            {
                var salt = _passwordService.GenerateSalt();
                var pass = _passwordService.HashPassword(registerDTO.Password, salt);
                registerDTO.Password = pass;

                var newUser = await _userService.RegisterNewUsersAsync(registerDTO, salt);
                await Login(new LoginUserDTO { Email = registerDTO.Email, Password = registerDTO.Password });

                return Ok(newUser);
            }
            else return BadRequest(registerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
