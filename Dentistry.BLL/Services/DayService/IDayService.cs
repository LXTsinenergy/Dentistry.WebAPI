using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ScheduleService
{
    public interface IDayService
    {
        Task<IEnumerable<Workday>> GetAllDaysAsync();
        Task<List<Workday>> GetCoincidingDaysAsync(Day dayOfWeek);
        Task<Workday> GetDayByIdAsync(int id);

        Task<bool> CreateDayAsync(WorkdayCreationDTO creationDTO);
        Task<bool> DeleteDayAsync(Workday workday);
    }
}
