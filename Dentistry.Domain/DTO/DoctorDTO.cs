using Dentistry.Domain.Enums;
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

        public List<AchievementDTO>? Achievements { get; set; }
        public List<CertificateDTO> Certificates { get; set; }
        public List<EducationDTO> Educations { get; set; }
        public List<PlaceOfWorkDTO> PlacesOfWork { get; set; }
        public List<ReviewDTO> Reviews { get; set; }

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
