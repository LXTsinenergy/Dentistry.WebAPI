using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Users.Queries.GetUserByPhone
{
    public class GetUserByPhoneQuery : IRequest<User>
    {
        public string PhoneNumber { get; set; }
    }
}
