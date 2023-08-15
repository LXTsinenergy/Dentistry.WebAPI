using Dentistry.BLL.Models.User;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.BookAppointment
{
    public class BookAppointmentCommand : IRequest<bool>
    {
        public UserAppointmentDto UserAppointmentDto { get; set; }
        public Note Note { get; set; }
    }
}
