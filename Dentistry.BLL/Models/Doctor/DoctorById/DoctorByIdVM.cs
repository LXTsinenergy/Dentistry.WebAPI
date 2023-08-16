using AutoMapper;
using Dentistry.BLL.Mapping;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Models.Doctor.DoctorById
{
    public class DoctorByIdVM : IMapWith<Domain.Models.Doctor>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Experience { get; set; }
        public List<string> Specialties { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<PlaceOfWork> PlacesOfWork { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Doctor, DoctorByIdVM>()
                .ForMember(vm => vm.Specialties,
                src => src.MapFrom(doctor => doctor.Specialties));
        }
    }
}
