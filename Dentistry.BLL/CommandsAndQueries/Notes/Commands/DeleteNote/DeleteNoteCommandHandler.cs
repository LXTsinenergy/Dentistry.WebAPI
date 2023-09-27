using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.NoteRepository;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public DeleteNoteCommandHandler(INoteRepository noteRepository) =>
            _noteRepository = noteRepository;

        public async Task<bool> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _noteRepository.DeleteAsync(request.Note, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(NoteRepository), ex.Message);
            }
        }
    }
}
