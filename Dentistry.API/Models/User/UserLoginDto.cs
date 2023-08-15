using System.ComponentModel.DataAnnotations;

namespace Dentistry.API.Models.User
{
    public class UserLoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Введите действительный Email-адрес")]
        public string Email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }
    }
}
