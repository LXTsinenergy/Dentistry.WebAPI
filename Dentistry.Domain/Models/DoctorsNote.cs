using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class DoctorsNote
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime AppointmentTime { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
