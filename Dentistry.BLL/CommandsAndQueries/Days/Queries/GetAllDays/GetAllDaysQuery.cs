using Dentistry.BLL.Models.Day.AllDaysList;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Days.Queries.GetAllDays
{
    public class GetAllDaysQuery : IRequest<AllDaysListVM>
    {
    }
}
