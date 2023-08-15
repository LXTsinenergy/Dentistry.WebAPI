namespace Dentistry.BLL.Models.Note.GeneralSchedule
{
    public class GeneralScheduleVM
    {
        public IList<GeneralScheduleNoteDto> Notes { get; set; }

        public GeneralScheduleVM()
        {
            Notes = new List<GeneralScheduleNoteDto>();
        }
    }
}
