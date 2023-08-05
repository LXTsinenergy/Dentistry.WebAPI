using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dentistry.Domain.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        public bool IsTaken { get; set; } = false;

        public string Comment { get; set; }
        public string PatientFullname { get; set; }
        public DateTime AppointmentTime { get; set; }

        public int DoctorId { get; set; }
        [JsonIgnore]
        public Doctor? Doctor { get; set; }

        public int WorkdayId { get; set; }
        [JsonIgnore]
        public Workday? Workday { get; set; }
    }
}
