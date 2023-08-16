using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.NoteRepository;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.BookAppointment
{
    internal class BookAppointmentCommandHandler : IRequestHandler<BookAppointmentCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public BookAppointmentCommandHandler(INoteRepository noteRepository) => 
            _noteRepository = noteRepository;

        public async Task<bool> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
        {
            request.Note.PatientFullname = request.UserAppointmentDto.Fullname;
            request.Note.PatientPhoneNumber = request.UserAppointmentDto.PhoneNumber;
            request.Note.PatientEmail = request.UserAppointmentDto.Email;
            request.Note.IsTaken = true;

            try
            {
                await _noteRepository.UpdateAsync(request.Note, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(NoteRepository), ex.Message);
            }
        }
    }
}
