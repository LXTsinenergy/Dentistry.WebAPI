using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<bool>
    {
        public int DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly AppointmentTime { get; set; }
    }
}
