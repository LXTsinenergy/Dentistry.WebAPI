using Dentistry.Domain.DTO.UserDTO.UserDTO;

namespace Dentistry.BLL.Services.AccountService
{
    public interface IAccountService
    {
        Task<bool> RegisterNewUserAsync(RegisterUserDTO registerDTO, byte[] passwordSalt);
    }
}
