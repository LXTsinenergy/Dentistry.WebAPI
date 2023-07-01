using Dentistry.Domain.Models;
using System.Security.Claims;

namespace Dentistry.BLL.Services.ClaimsService
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsPrincipal CreateClaimsPrincipal(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsPrincipal;
        }
    }
}
