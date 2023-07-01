using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmedPassword { get; set; }

        public string PhoneNumber { get; set; }
    }
}
