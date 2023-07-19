using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO
{
    public class DoctorDataDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
