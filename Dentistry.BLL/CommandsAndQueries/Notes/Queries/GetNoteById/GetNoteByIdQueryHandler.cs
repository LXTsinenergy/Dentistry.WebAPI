using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, Note>
    {
        private readonly INoteRepository _noteRepository;

        public GetNoteByIdQueryHandler(INoteRepository noteRepository) =>
            _noteRepository = noteRepository;

        public async Task<Note> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var note = await _noteRepository.GetByIdAsync(request.Id);
                return note;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(NoteRepository), ex.Message);
            }
        }
    }
}
