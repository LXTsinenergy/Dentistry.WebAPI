using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
    }
}