using System.ComponentModel.DataAnnotations;

namespace Dentistry.API.Models
{
    public class UserRegisterDto
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Введите действительный Email-адрес")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string ConfirmedPassword { get; set; }

        [Required]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = "Введите действительный номер телефона")]
        public string PhoneNumber { get; set; }
    }
}
