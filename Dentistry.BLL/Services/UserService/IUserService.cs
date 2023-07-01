using Dentistry.Domain.DTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<User> RegisterNewUser(RegisterDTO registerDTO);
        Task<User> AddNewUser(UserDTO userDTO);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserByEmailAsync(string email);
    }
}
