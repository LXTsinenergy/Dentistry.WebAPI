using AutoMapper;
using Dentistry.BLL.Mapping;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Models.Specialties.AllSpecialties
{
    public class SpecialityForAllDto : IMapWith<Speciality>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Doctors { get; set; }

        public SpecialityForAllDto()
        {
            Doctors = new List<string>();
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Speciality, SpecialityForAllDto>();
        }
    }
}
