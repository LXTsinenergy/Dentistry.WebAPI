using AutoMapper;
using Dentistry.BLL.Mapping;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Models.Notes
{
    public class FreeNoteDto : IMapWith<Note>
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int DoctorId { get; set; }
        public int WorkdayId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, FreeNoteDto>();
        }
    }
}
