using AutoMapper;
using Dentistry.BLL.Models.Note.DaySchedule;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetDayDoctorNotes
{
    public class GetDayDoctorNotesQueryHandler : IRequestHandler<GetDayDoctorNotesQuery, DayNotesListVM>
    {
        private readonly IMapper _mapper;

        public GetDayDoctorNotesQueryHandler(IMapper mapper) => _mapper = mapper;

        public Task<DayNotesListVM> Handle(GetDayDoctorNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = request.Doctor.Notes
                .Where(note => note.AppointmentTime.Date == DateTime.Parse(request.Date.ToString()));
            var notesListVM = new DayNotesListVM();

            foreach (var note in notes)
            {
                var noteDto = _mapper.Map<DayNoteDto>(note);
                notesListVM.Notes.Add(noteDto);
            }
            return Task.FromResult(notesListVM);
        }
    }
}
