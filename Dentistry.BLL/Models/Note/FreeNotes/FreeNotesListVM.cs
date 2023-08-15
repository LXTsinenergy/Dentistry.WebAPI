namespace Dentistry.BLL.Models.Note.FreeNotes
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
