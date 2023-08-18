using AutoMapper;
using Dentistry.BLL.CommandsAndQueries.Doctors.Commands.UpdateDoctor;
using Dentistry.BLL.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.API.Models.Doctor
{
    public class DoctorUpdateDto : IMapWith<UpdateDoctorCommand>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Experience { get; set; }
        public List<int> SpecialtiesId { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Введите действительный Email-адрес")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Введите действительный номер телефона")]
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DoctorUpdateDto, UpdateDoctorCommand>();
        }
    }
}
