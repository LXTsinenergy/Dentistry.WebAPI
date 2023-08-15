using AutoMapper;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.User
{
    public class UserAppointmentDto : IMapWith<Domain.Models.User>
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.User, UserAppointmentDto>();
        }
    }
}
