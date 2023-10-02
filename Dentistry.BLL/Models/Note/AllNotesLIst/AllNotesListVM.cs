namespace Dentistry.BLL.Models.Note.AllNotesLIst
{
    public class AllNotesListVM
    {
        public List<NoteForAllDto> Notes;

        public AllNotesListVM() => Notes = new();
    }
}
