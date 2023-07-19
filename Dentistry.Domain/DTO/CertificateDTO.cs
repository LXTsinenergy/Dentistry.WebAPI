using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO
{
    public class CertificateDTO : DoctorDataDTO
    {
        [Required]
        public DateTime Validity { get; set; }
    }
}
