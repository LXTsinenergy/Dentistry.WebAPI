using Dentistry.BLL.Services.AccountService;
using Dentistry.BLL.Services.ClaimsService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("account")]
    [Authorize(Roles = "admin, user")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
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

        #region Login/Register/Logout
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginDTO loginDTO)
        {
            var user = await _userService.GetUserByEmailAsync(loginDTO.Email);

            if (user == null) return NotFound();
            if (user.Password != _passwordService.HashPassword(loginDTO.Password, user.Salt))
            {
                return BadRequest(loginDTO.Password);
            }

            var claimsPrincipal = _claimsService.CreateClaimsPrincipal(user);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return Ok();
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserRegisterDTO registerDTO)
        {
            var user = await _userService.GetUserByEmailAsync(registerDTO.Email);

            if (user == null) return BadRequest(registerDTO);

            if (registerDTO.Password == registerDTO.ConfirmedPassword)
            {
                var salt = _passwordService.GenerateSalt();
                var password = _passwordService.HashPassword(registerDTO.Password, salt);
                registerDTO.Password = password;

                var newUser = await _accountService.RegisterNewUserAsync(registerDTO, salt);
                await LoginAsync(new UserLoginDTO { Email = registerDTO.Email, Password = registerDTO.Password });

                return Ok();
            }
            return BadRequest();
        }

        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
        #endregion
    }
}
