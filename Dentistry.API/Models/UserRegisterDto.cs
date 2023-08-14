using AutoMapper;
using Dentistry.BLL.Mapping;
using Dentistry.BLL.Users.Commands.CreateUser;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.API.Models
{
    public class UserRegisterDto : IMapWith<CreateUserCommand>
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Введите действительный Email-адрес")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        [Required]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Введите действительный номер телефона")]
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile) => 
            profile.CreateMap<UserRegisterDto, CreateUserCommand>();
    }
}
