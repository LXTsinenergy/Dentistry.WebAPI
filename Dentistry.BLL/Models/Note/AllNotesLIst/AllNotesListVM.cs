namespace Dentistry.BLL.Models.Note.AllNotesLIst
{
    public class AllNotesListVM
    {
        public IList<NoteForAllDto> Notes { get; set; }

        public AllNotesListVM()
        {
            Notes = new List<NoteForAllDto>();
        }
    }
}
