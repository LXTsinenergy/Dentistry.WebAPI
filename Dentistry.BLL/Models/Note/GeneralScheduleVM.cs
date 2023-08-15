namespace Dentistry.BLL.Models.Note
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
