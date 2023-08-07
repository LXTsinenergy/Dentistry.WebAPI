using System.ComponentModel.DataAnnotations;

namespace Dentistry.Domain.DTO.UserDTO.UserDTO
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Введите действительный Email-адрес")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
