using Dentistry.Domain.DTO.User;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<User> RegisterNewUsersAsync(RegisterUserDTO registerDTO, byte[] passwordSalt);
        Task<User> AddNewUserAsync(UserDTO userDTO, byte[] passwordSalt);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByPhoneNumberAsync(string phoneNumber);

    }
}
