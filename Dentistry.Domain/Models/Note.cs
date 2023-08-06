using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dentistry.Domain.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        public bool IsTaken { get; set; } = false;
        public bool IsAccepted { get; set; } = false;

        public string Comment { get; set; } = string.Empty;
        public string PatientFullname { get; set; } = string.Empty;
        public string PatientPhoneNumber { get; set; } = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;

        public string ProcedureName { get; set; } = string.Empty;
        public DateTime AppointmentTime { get; set; }

        public int DoctorId { get; set; }
        [JsonIgnore]
        public Doctor? Doctor { get; set; }

        public int WorkdayId { get; set; }
        [JsonIgnore]
        public Workday? Workday { get; set; }
    }
}
