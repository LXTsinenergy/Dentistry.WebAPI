using AutoMapper;
using Dentistry.BLL.CommandsAndQueries.Specialties.Commands.CreateSpeciality;
using Dentistry.BLL.Mapping;

namespace Dentistry.API.Models.Speciality
{
    public class SpecialityCreateDto : IMapWith<CreateSpecialityCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SpecialityCreateDto, CreateSpecialityCommand>();
        }
    }
}
