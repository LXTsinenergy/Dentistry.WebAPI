namespace Dentistry.BLL.Models.Note.DaySchedule
{
    public class DayNotesListVM
    {
        public IList<DayNoteDto> Notes { get; set; }

        public DayNotesListVM()
        {
            Notes = new List<DayNoteDto>();
        }
    }
}
