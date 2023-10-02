using Dentistry.BLL.Models.Note.GeneralSchedule;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Notes.Queries.GetDoctorNotes
{
    public class GetDoctorNotesQuery : IRequest<DoctorNotesListVM>
    {
        public Doctor Doctor { get; set; }
    }
}
