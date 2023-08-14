using AutoMapper;
using Dentistry.API.Models;
using Dentistry.BLL.Services.AccountService;
using Dentistry.BLL.Services.ClaimsService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.BLL.Users.Commands.CreateUser;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("account")]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IClaimsService _claimsService;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService,
            IAccountService accountService,
            IClaimsService claimsService,
            IPasswordService passwordService,
            IMapper mapper)
        {
            _userService = userService;
            _accountService = accountService;
            _claimsService = claimsService;
            _passwordService = passwordService;
            _mapper = mapper;
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
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto userRegisterDTO)
        {
            //var user = await _userService.GetUserByEmailAsync(userRegisterDTO.Email);

            //if (user != null) return BadRequest(userRegisterDTO);

            //if (userRegisterDTO.Password == userRegisterDTO.ConfirmedPassword)
            //{
            //    var salt = _passwordService.GenerateSalt();
            //    var password = _passwordService.HashPassword(userRegisterDTO.Password, salt);
            //    userRegisterDTO.Password = password;

            //    var result = await _accountService.RegisterNewUserAsync(userRegisterDTO, salt);

            //    if (result)
            //    {
            //        await LoginAsync(new UserLoginDTO { Email = userRegisterDTO.Email, Password = userRegisterDTO.Password });
            //        return Ok();
            //    }
            //    return StatusCode(500);
            //}
            //return BadRequest
            var command = _mapper.Map<CreateUserCommand>(userRegisterDTO);
            throw new NotImplementedException();
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
