using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.Users.Commands.CreateUser
{
    public class AddUserCommand : IRequest<User>
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
    }
}