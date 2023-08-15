using AutoMapper;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.Note.GeneralSchedule
{
    public class GeneralScheduleNoteDto : IMapWith<Domain.Models.Note>
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int WorkdayId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Note, GeneralScheduleNoteDto>();
        }
    }
}
