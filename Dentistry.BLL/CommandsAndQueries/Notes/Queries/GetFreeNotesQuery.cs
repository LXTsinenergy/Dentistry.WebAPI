using Dentistry.BLL.Models.Notes;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries
{
    public class GetFreeNotesQuery : IRequest<FreeNotesListVM>
    {
    }
}
