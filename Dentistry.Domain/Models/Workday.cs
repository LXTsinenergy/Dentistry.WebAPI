using Dentistry.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Workday
    {
        [Key]
        public int Id { get; set; }

        public Day DayOfWeek { get; set; }
        public ICollection<Note> Schedule { get; set; }

        public Workday()
        {
            Schedule = new List<Note>();
        }
    }
}
