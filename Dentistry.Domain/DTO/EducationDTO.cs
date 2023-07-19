using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO
{
    public class EducationDTO : DoctorDataDTO
    {
        [Required]
        public DateTime DateOfEducation { get; set; }
    }
}
