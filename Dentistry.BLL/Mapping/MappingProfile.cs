using AutoMapper;
using Dentistry.Domain.DTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<DoctorDTO, Doctor>();
        }
    }
}
