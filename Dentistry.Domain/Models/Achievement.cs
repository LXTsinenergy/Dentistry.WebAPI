using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Achievement
    {
        [Required]
        public string Name { get; set; }
        public DateOnly? AchievementDate { get; set; }
    }
}
