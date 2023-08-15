namespace Dentistry.BLL.Models.Notes
{
    public class FreeNotesListVM
    {
        public IList<FreeNoteDto> FreeNotes { get; set; }

        public FreeNotesListVM()
        {
            FreeNotes = new List<FreeNoteDto>();
        }
    }
}
