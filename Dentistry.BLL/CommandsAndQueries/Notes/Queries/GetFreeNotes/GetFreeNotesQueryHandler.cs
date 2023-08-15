using AutoMapper;
using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Models.Note.FreeNotes;
using Dentistry.DAL.Repositories.NoteRepository;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetFreeNotes
{
    public class GetFreeNotesQueryHandler : IRequestHandler<GetFreeNotesQuery, FreeNotesListVM>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public GetFreeNotesQueryHandler(INoteRepository noteRepository,
            IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }


        public async Task<FreeNotesListVM> Handle(GetFreeNotesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var notes = await _noteRepository.GetAllAsync();
                var freeNotesList = new FreeNotesListVM();

                if (notes != null)
                {
                    var freeNotes = notes
                        .Where(note => !note.IsTaken);

                    foreach (var note in freeNotes)
                    {
                        var freeNote = _mapper.Map<FreeNoteDto>(note);
                        freeNotesList.FreeNotes.Add(freeNote);
                    }
                }
                return freeNotesList;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(NoteRepository), ex.Message);
            }
        }
    }
}
