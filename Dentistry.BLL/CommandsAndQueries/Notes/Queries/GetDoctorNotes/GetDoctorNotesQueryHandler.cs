using AutoMapper;
using Dentistry.BLL.Models.Note.GeneralSchedule;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetDoctorNotes
{
    public class GetDoctorNotesQueryHandler : IRequestHandler<GetDoctorNotesQuery, DoctorNotesListVM>
    {
        private readonly IMapper _mapper;

        public GetDoctorNotesQueryHandler(IMapper mapper) => _mapper = mapper;

        public Task<DoctorNotesListVM> Handle(GetDoctorNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = new DoctorNotesListVM();

            foreach (var note in request.Doctor.Notes)
            {
                var noteDto = _mapper.Map<DoctorNoteDto>(note);
                notes.Notes.Add(noteDto);
            }
            return Task.FromResult(notes);
        }
    }
}
