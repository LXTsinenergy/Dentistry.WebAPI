using MediatR;

namespace Dentistry.BLL.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
