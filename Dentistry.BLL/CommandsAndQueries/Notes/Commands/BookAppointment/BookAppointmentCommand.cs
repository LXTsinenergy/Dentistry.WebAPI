using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.BookAppointment
{
    public class BookAppointmentCommand : IRequest<bool>
    {
        public User User { get; set; }
        public Note Note { get; set; }
    }
}
