using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.ResetNote
{
    public class ResetNoteCommandHandler : IRequestHandler<ResetNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public ResetNoteCommandHandler(INoteRepository noteRepository) => 
            _noteRepository = noteRepository;

        public async Task<bool> Handle(ResetNoteCommand request, CancellationToken cancellationToken)
        {
            request.Note.IsTaken = false;
            request.Note.IsAccepted = false;
            request.Note.Comment = string.Empty;
            request.Note.PatientFullname = string.Empty;
            request.Note.PatientPhoneNumber = string.Empty;
            request.Note.PatientEmail = string.Empty;
            request.Note.ProcedureName = string.Empty;

            try
            {
                await _noteRepository.UpdateAsync(request.Note);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(NoteRepository), ex.Message);
            }
        }
    }
}
