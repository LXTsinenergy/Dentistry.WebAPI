using Dentistry.Domain.DTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<User> AddAsync(UserDTO userDTO);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetUserByEmailAsync(string email);
    }
}
