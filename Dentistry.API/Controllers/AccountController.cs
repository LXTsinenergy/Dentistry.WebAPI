using Dentistry.BLL.Services.ClaimsService;
using Dentistry.BLL.Services.UserService;
using Dentistry.Domain.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dentistry.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IClaimsService _claimsService;

        public AccountController(IUserService userService, IClaimsService claimsService)
        {
            _userService = userService;
            _claimsService = claimsService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userService.GetUserByEmailAsync(loginDTO.Email);

            if (user == null) return NotFound();

            var claimsPrincipal = _claimsService.CreateClaimsPrincipal(user);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            
            return Ok(loginDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var possibleUser = await _userService.GetUserByEmailAsync(registerDTO.Email);

            if (possibleUser != null) return BadRequest(registerDTO);

            if (registerDTO.Password == registerDTO.ConfirmedPassword)
            {
                var newUser = await _userService.RegisterNewUser(registerDTO);
                return Ok(newUser);
            }
            else return BadRequest(registerDTO);
        }
    }
}
