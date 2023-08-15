using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
