using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime DateOfReview { get; set; }
    }
}
