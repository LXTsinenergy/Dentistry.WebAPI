using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dentistry.Domain.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Doctor> Doctors { get; set; }
    }
}
