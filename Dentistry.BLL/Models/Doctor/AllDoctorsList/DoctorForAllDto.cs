using AutoMapper;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.Doctor.DoctorForAll
{
    public class DoctorForAllDto : IMapWith<Domain.Models.Doctor>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Experience { get; set; }
        public List<string> Specialties { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Doctor, DoctorForAllDto>()
                .ForMember(dto => dto.Specialties,
                src => src.MapFrom(doctor => doctor.Specialties));
        }
    }
}
