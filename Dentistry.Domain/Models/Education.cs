using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Education : DoctorData
    {
        [Required]
        public DateTime DateOfEducation { get; set; }
    }
}
