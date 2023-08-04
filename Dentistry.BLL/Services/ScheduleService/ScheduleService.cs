using AutoMapper;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IDayRepository dayRepository, IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Workday>> GetAllDaysAsync()
        {
            try
            {
                var days = await _dayRepository.GetAllDaysAsync();
                return days;
            }
            catch
            {
                return Enumerable.Empty<Workday>();
            }
        }

        public async Task<Workday> GetDayByIdAsync(int id)
        {
            try
            {
                var days = await _dayRepository.GetAllDaysAsync();
                var day = days
                    .Where(d => d.Id == id)
                    .FirstOrDefault();

                return day;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateNewDayAsync(WorkdayCreationDTO creationDTO)
        {
            var day = _mapper.Map<Workday>(creationDTO);

            try
            {
                await _dayRepository.AddNewDayAsync(day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Workday>> GetCoincidingDaysAsync(Day dayOfWeek)
        {
            try
            {
                var days = await _dayRepository.GetAllDaysAsync();
                var coincidingDays = days
                    .Where(d => d.DayOfWeek == dayOfWeek)
                    .ToList();
                return coincidingDays;
            }
            catch
            {
                return new List<Workday>();
            }
        }

        public async Task<bool> DeleteDayAsync(Workday workday)
        {
            try
            {
                await _dayRepository.DeleteDayAsync(workday);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
