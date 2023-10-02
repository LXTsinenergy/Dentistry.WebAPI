using Dentistry.BLL.Models.Note.AllNotesLIst;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetAllNotes
{
    public class GetAllNotesQuery : IRequest<AllNotesListVM>
    {
    }
}
