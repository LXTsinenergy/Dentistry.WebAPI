using AutoMapper;
using Dentistry.BLL.Mapping;
using Dentistry.BLL.Models.Note.DaySchedule;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Models.Day.AllDaysList
{
    public class DayForAllDto : IMapWith<Workday>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public IList<DayScheduleNoteDto> Schedule { get; set; }

        public DayForAllDto()
        {
            Schedule = new List<DayScheduleNoteDto>();
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Workday, DayForAllDto>()
                .ForMember(dest => dest.Date,
                opt => opt.MapFrom(x => new DateOnly(x.Date.Year, x.Date.Month, x.Date.Day)));
        }
    }
}
