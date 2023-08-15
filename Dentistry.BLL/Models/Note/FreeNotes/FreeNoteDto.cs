using AutoMapper;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.Note.FreeNotes
{
    public class FreeNoteDto : IMapWith<Domain.Models.Note>
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int DoctorId { get; set; }
        public int WorkdayId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Note, FreeNoteDto>();
        }
    }
}
