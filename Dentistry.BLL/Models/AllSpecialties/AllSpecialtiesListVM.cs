namespace Dentistry.BLL.Models.AllSpecialties
{
    public class AllSpecialtiesListVM
    {
        public IList<SpecialityForAllDto> Specialties { get; set; }

        public AllSpecialtiesListVM()
        {
            Specialties = new List<SpecialityForAllDto>();
        }
    }
}
