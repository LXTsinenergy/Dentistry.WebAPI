using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQuery : IRequest<Note>
    {
        public int Id { get; set; }
    }
}
