using AutoMapper;
using Dentistry.Domain.DTO.DoctorDTO;
using Dentistry.Domain.DTO.User;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<Doctor, DoctorCreationDTO>();
            CreateMap<DoctorCreationDTO, Doctor>();
        }
    }
}
