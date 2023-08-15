using Dentistry.BLL.Models.Note.FreeNotes;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetFreeNotes
{
    public class GetFreeNotesQuery : IRequest<FreeNotesListVM>
    {
    }
}
