using AutoMapper;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.Domain.DTO.Day;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.ScheduleService
{
    public class DayService : IDayService
    {
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;

        public DayService(IDayRepository dayRepository, IMapper mapper)
        {
            _dayRepository = dayRepository;
            _mapper = mapper;
        }

        #region Get
        public async Task<IEnumerable<Workday>> GetAllDaysAsync()
        {
            try
            {
                var days = await _dayRepository.GetAllAsync();
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
                var days = await _dayRepository.GetAllAsync();
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

        public async Task<List<Workday>> GetCoincidingDaysAsync(Day dayOfWeek)
        {
            try
            {
                var days = await _dayRepository.GetAllAsync();
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
        #endregion

        #region Day operations
        public async Task<bool> CreateDayAsync(WorkdayCreationDTO creationDTO)
        {
            try
            {
                var day = _mapper.Map<Workday>(creationDTO);

                await _dayRepository.AddAsync(day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDayAsync(Workday workday)
        {
            try
            {
                await _dayRepository.DeleteAsync(workday);
                return true;
            }
            catch
            {
                return false;
            }
        } 
        #endregion
    }
}
