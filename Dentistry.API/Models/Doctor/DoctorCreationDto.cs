using AutoMapper;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.CreateDoctor;
using Dentistry.BLL.Mapping;
using Dentistry.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.API.Models.Doctor
{
    public class DoctorCreationDto : IMapWith<CreateDoctorCommand>
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public List<Speciality> Specialties { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Введите действительный Email-адрес")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Введите действительный номер телефона")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DoctorCreationDto, CreateDoctorCommand>();
        }
    }
}
