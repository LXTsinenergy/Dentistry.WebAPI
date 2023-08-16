using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task AddAsync(User user, CancellationToken cancellationToken);
        Task UpdateAsync(User user, CancellationToken cancellationToken);
        Task DeleteAsync(User user, CancellationToken cancellationToken);

        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);
    }
}
