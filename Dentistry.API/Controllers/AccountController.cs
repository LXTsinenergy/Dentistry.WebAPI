using AutoMapper;
using Dentistry.API.Models;
using Dentistry.BLL.Services.AccountService;
using Dentistry.BLL.Services.ClaimsService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.UserService;
using Dentistry.BLL.Users.Commands.CreateUser;
using Dentistry.BLL.Users.Queries.GetUserByEmail;
using Dentistry.BLL.Users.Queries.GetUserByPhone;
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
            var getUserByEmailQuery = new GetUserByEmailQuery { Email = userRegisterDTO.Email };
            var userByEmail = await Mediator.Send(getUserByEmailQuery, CancellationToken.None);
            if (userByEmail != null)
            {
                return Conflict(userRegisterDTO.Email);
            }

            var getUserByPhoneQuery = new GetUserByPhoneQuery { PhoneNumber = userRegisterDTO.PhoneNumber };
            var userByPhone = await Mediator.Send(getUserByPhoneQuery, CancellationToken.None);
            if (userByPhone != null)
            {
                return Conflict(userRegisterDTO.PhoneNumber);
            }

            var command = _mapper.Map<CreateUserCommand>(userRegisterDTO);
            var result = await Mediator.Send(command, CancellationToken.None);
            return Ok(result);
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
