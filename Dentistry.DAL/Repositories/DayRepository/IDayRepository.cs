using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DayRepository
{
    public interface IDayRepository
    {
        Task<IEnumerable<Workday>> GetAllDays();
    }
}
