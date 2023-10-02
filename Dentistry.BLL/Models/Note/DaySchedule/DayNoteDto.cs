using AutoMapper;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.Note.DaySchedule
{
    public class DayNoteDto : IMapWith<Domain.Models.Note>
    {
        public int Id { get; set; }

        public string PatientFullname { get; set; }
        public string PatientPhoneNumber { get; set; }
        public string PatientEmail { get; set; }

        public string ProcedureName { get; set; }
        public DateTime AppointmentTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Note, DayNoteDto>();
        }
    }
}
