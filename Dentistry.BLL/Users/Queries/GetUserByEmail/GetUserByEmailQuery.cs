using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}
