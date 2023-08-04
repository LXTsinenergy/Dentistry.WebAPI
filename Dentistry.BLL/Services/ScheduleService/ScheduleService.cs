using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly IDayRepository _dayRepository;

        public ScheduleService(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public async Task<IEnumerable<Workday>> GetAllDays()
        {
            try
            {
                var days = await _dayRepository.GetAllDays();
                return days;
            }
            catch
            {
                return Enumerable.Empty<Workday>();
            }
        }
    }
}
