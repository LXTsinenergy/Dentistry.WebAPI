using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ScheduleService
{
    public interface IScheduleService
    {
        Task<IEnumerable<Workday>> GetAllDaysAsync();
        Task<Workday> GetDayByIdAsync(int id);
        Task<bool> CreateNewDayAsync(WorkdayCreationDTO creationDTO);
        Task<bool> DeleteDayAsync(Workday workday);
        Task<List<Workday>> GetCoincidingDaysAsync(Day dayOfWeek);
    }
}
