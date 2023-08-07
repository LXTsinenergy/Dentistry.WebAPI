using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO.Review
{
    public class ReviewCreationDTO
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
