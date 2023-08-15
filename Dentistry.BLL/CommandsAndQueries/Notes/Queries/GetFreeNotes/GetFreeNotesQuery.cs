using Dentistry.BLL.Models.Notes;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetFreeNotes
{
    public class GetFreeNotesQuery : IRequest<FreeNotesListVM>
    {
    }
}
