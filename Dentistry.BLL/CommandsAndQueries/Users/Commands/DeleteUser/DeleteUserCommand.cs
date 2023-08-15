using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
