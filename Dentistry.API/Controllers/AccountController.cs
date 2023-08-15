using AutoMapper;
using Dentistry.API.Models.User;
using Dentistry.BLL.CommandsAndQueries.Users.Commands.CreateUser;
using Dentistry.BLL.CommandsAndQueries.Users.Queries.GetUserByEmail;
using Dentistry.BLL.CommandsAndQueries.Users.Queries.GetUserByPhone;
using Dentistry.BLL.Helpers;
using Dentistry.BLL.Services.ClaimsService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.API.Controllers
{
    [Route("account")]
    public class AccountController : BaseController
    {
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;

        public AccountController(IClaimsService claimsService, IMapper mapper) =>
            (_claimsService, _mapper) = (claimsService, mapper);

        #region Login/Register/Logout
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto loginDTO)
        {
            var getUserByEmailQuery = new GetUserByEmailQuery { Email =  loginDTO.Email };
            var user = await Mediator.Send(getUserByEmailQuery);
            if (user == null)
            {
                return NotFound(loginDTO.Email);
            }

            if (user.Password != PasswordHelper.HashPassword(loginDTO.Password, user.Salt))
            {
                return Unauthorized(loginDTO.Password);
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
