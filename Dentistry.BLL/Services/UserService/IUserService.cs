using Dentistry.Domain.DTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<User> RegisterNewUser(RegisterDTO registerDTO, byte[] passwordSalt);
        Task<User> AddNewUser(UserDTO userDTO, byte[] passwordSalt);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserByEmailAsync(string email);
    }
}
