using Dentistry.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Doctor : User
    {
        [Required]
        public string Surname { get ;set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public List<Specialties> Specialties { get; set; }

        public List<Achievement>? Achievements { get; set; }

        [Required]
        public List<string> Certificates { get; set; }

        [Required]
        public List<string> Education { get; set; }

        [Required]
        public List<string> PlacesOfWork { get; set; }

        [Required]
        public List<string> Reviews { get; set; }
    }
}
