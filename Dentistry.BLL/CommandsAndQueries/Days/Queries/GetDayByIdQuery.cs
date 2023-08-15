using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Days.Queries
{
    public class GetDayByIdQuery : IRequest<Workday>
    {
        public int Id { get; set; }
    }
}
