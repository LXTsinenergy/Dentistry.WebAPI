using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DayRepository
{
    public interface IDayRepository
    {
        Task<IEnumerable<Workday>> GetAllAsync();
        Task<Workday> GetByIdAsync(int id);
        Task AddAsync(Workday workday, CancellationToken cancellationToken);
        Task DeleteAsync(Workday workday, CancellationToken cancellationToken);
        Task<Workday> GetByDateAsync(DateOnly date, CancellationToken cancellationToken);
    }
}
