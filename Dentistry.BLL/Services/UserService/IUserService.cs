using Dentistry.Domain.DTO.User;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterNewUsersAsync(RegisterUserDTO registerDTO, byte[] passwordSalt);
        Task<bool> AddNewUserAsync(UserDTO userDTO, byte[] passwordSalt);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByPhoneNumberAsync(string phoneNumber);

        Task<bool> EmailIsRegistered(string email);
        Task<bool> PhoneIsRegistered(string phone);
    }
}
