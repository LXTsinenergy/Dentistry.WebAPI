using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Domain.Models
{
    public class DoctorData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
