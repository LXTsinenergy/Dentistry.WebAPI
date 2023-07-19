using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO
{
    public class ReviewDTO : DoctorDataDTO
    {
        [Required]
        public string Text { get; set; }

        public DateTime DateOfReview { get; set; }
    }
}
