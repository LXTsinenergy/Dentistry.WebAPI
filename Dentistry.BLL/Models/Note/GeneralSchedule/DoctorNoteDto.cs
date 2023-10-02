using AutoMapper;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.Note.GeneralSchedule
{
    public class DoctorNoteDto : IMapWith<Domain.Models.Note>
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Note, DoctorNoteDto>();
        }
    }
}
