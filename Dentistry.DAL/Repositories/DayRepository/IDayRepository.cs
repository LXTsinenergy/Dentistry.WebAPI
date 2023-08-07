using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DayRepository
{
    public interface IDayRepository
    {
        Task<IEnumerable<Workday>> GetAllAsync();
        Task<Workday> GetByIdAsync(int id);
        Task AddAsync(Workday workday);
        Task DeleteAsync(Workday workday);
    }
}
