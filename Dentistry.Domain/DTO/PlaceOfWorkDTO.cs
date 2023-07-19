using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO
{
    public class PlaceOfWorkDTO : DoctorDataDTO
    {
        [Required]
        public DateTime WorkingYears { get; set; }
    }
}
