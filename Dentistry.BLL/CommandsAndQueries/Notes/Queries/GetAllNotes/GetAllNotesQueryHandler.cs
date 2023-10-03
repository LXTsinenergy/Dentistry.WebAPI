using AutoMapper;
using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Models.Note.AllNotesLIst;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetAllNotes
{
    public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery, AllNotesListVM>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _notesRepository;

        public GetAllNotesQueryHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _notesRepository = noteRepository;
        }

        public async Task<AllNotesListVM> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var notes = await _notesRepository.GetAllAsync();
                var notesVM = new AllNotesListVM() ;

                if (notes != null)
                {
                    foreach (var note in notes)
                    {
                        NoteForAllDto noteDto = _mapper.Map<NoteForAllDto>(note);
                        notesVM.Notes.Add(noteDto);
                    }
                }
                return notesVM;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }
    }
}
