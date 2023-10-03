using AutoMapper;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.Note.AllNotesLIst
{
    public class NoteForAllDto : IMapWith<Domain.Models.Note>
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string PatientFullname { get; set; } = string.Empty;
        public string PatientPhoneNumber { get; set; } = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;
        public string ProcedureName { get; set; } = string.Empty;
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string DoctorName { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Note, NoteForAllDto>()
                .ForMember(dto => dto.AppointmentDate, 
                src => src.MapFrom(note => DateOnly.FromDateTime(note.AppointmentTime)))
                .ForMember(dto => dto.AppointmentTime,
                src => src.MapFrom(note => TimeOnly.FromDateTime(note.AppointmentTime)));
        }
    }
}
