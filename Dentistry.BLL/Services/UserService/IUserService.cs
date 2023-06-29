using Dentistry.Domain.DTO;

namespace Dentistry.BLL.Services.UserService
{
    public interface IUserService
    {
        Task Add(UserDTO userDTO);
    }
}
