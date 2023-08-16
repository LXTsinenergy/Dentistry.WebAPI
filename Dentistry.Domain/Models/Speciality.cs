using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dentistry.Domain.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? DoctorId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
