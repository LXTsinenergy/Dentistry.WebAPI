using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Days.Queries.GetDayById
{
    public class GetDayByIdQuery : IRequest<Workday>
    {
        public int Id { get; set; }
    }
}
