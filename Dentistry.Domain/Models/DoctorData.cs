using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dentistry.Domain.Models
{
    public class DoctorData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? DoctorId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
