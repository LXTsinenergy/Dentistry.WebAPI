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
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IClaimsService _claimsService;

        public LoginController(IUserService userService, IClaimsService claimsService)
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
    }
}
