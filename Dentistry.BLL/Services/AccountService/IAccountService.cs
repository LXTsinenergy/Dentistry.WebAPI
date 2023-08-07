using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.AccountService
{
    public interface IAccountService
    {
        Task<bool> RegisterNewUserAsync(UserRegisterDTO registerDTO, byte[] passwordSalt);
    }
}
