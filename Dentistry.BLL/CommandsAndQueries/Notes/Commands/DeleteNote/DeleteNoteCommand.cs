using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<bool>
    {
        public Note Note { get; set; }
    }
}
