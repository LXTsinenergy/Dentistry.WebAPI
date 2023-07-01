using Dentistry.Domain.Models;
using System.Security.Claims;

namespace Dentistry.BLL.Services.ClaimsService
{
    public interface IClaimsService
    {
        ClaimsPrincipal CreateClaimsPrincipal(User user);
    }
}
