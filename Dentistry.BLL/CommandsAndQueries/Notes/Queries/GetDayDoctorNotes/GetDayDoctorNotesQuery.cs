using Dentistry.BLL.Models.Note.DaySchedule;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetDayDoctorNotes
{
    public class GetDayDoctorNotesQuery : IRequest<DayNotesListVM>
    {
        public Doctor Doctor { get; set; }
        public DateOnly Date {  get; set; }
    }
}
