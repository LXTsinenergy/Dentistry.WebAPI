using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task Add(User user);
    }
}
