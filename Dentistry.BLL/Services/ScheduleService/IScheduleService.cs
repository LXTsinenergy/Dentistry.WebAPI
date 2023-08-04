using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ScheduleService
{
    public interface IScheduleService
    {
        Task<IEnumerable<Workday>> GetAllDays();
    }
}
