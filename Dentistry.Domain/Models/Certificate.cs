using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Certificate : DoctorData
    {
        [Required]
        public DateTime Validity { get; set; }
    }
}
