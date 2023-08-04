using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DayRepository
{
    public interface IDayRepository
    {
        Task<IEnumerable<Workday>> GetAllDaysAsync();
        Task AddNewDayAsync(Workday workday);
        Task DeleteDayAsync(Workday workday);
    }
}
