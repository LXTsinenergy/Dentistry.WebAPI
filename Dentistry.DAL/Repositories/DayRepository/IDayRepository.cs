using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DayRepository
{
    public interface IDayRepository
    {
        Task<IEnumerable<Workday>> GetAllDaysAsync();
        Task<Workday> GetDayByIdAsync(int id);
        Task AddNewDayAsync(Workday workday);
        Task DeleteDayAsync(Workday workday);
    }
}
