using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO
{
    public class DoctorDTO
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public List<Speciality> Specialties { get; set; }

        public List<Achievement>? Achievements { get; set; }
        public List<string> Certificates { get; set; }
        public List<string> Education { get; set; }
        public List<string> PlacesOfWork { get; set; }
        public List<string> Reviews { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Введите действительный Email-адрес")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = "Введите действительный номер телефона")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
