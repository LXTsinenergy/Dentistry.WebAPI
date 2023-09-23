using AutoMapper;
using Dentistry.BLL.CommandsAndQueries.Notes.Commands.CreateNote;
using Dentistry.BLL.Mapping;

namespace Dentistry.BLL.Models.Note.CreateNote
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        public int DoctorId { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly AppointmentTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>();
        }
    }
}
