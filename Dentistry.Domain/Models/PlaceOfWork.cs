using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class PlaceOfWork : DoctorData
    {
        [Required]
        public DateTime WorkingYears { get; set; }
    }
}
