using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.ResetNote
{
    public class ResetNoteCommand : IRequest<bool>
    {
        public Note Note { get; set; }
    }
}
