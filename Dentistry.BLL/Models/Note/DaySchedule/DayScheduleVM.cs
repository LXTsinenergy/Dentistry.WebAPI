namespace Dentistry.BLL.Models.Note.DaySchedule
{
    public class DayScheduleVM
    {
        public IList<DayScheduleNoteDto> Notes { get; set; }

        public DayScheduleVM()
        {
            Notes = new List<DayScheduleNoteDto>();
        }
    }
}
