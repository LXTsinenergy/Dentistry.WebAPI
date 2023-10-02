namespace Dentistry.BLL.Models.Note.GeneralSchedule
{
    public class DoctorNotesListVM
    {
        public IList<DoctorNoteDto> Notes { get; set; }

        public DoctorNotesListVM()
        {
            Notes = new List<DoctorNoteDto>();
        }
    }
}
