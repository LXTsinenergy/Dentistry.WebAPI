using Dentistry.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public int Experience { get; set; }

        public ICollection<DoctorsNote> Notes { get; set; }

        [Required]
        public List<Speciality> Specialties { get; set; }

        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<PlaceOfWork> PlacesOfWork { get; set; }
        public ICollection<Review> Reviews { get; set; }

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
        public byte[] Salt { get; set; }

        public Role Role { get; set; }

        public Doctor()
        {
            Notes = new List<DoctorsNote>();
            Achievements = new List<Achievement>();
            Certificates = new List<Certificate>();
            Educations = new List<Education>();
            PlacesOfWork = new List<PlaceOfWork>();
            Reviews = new List<Review>();
        }
    }
}
