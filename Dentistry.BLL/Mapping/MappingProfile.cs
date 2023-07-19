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

            CreateMap<DoctorDTO, Doctor>()
                .ForMember(dest => dest.Achievements, opt => opt.MapFrom(src => src.Achievements))
                .ForMember(dest => dest.Certificates, opt => opt.MapFrom(src => src.Certificates))
                .ForMember(dest => dest.Educations, opt => opt.MapFrom(src => src.Educations))
                .ForMember(dest => dest.PlacesOfWork, opt => opt.MapFrom(src => src.PlacesOfWork))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));

            CreateMap<AchievementDTO, Achievement>();
            CreateMap<CertificateDTO, Certificate>();
            CreateMap<EducationDTO, Education>();
            CreateMap<PlaceOfWorkDTO, PlaceOfWork>();
            CreateMap<ReviewDTO, Review>();

            CreateMap<Doctor, DoctorDTO>();
        }
    }
}
