namespace Dentistry.BLL.Models.Day.AllDaysList
{
    public class AllDaysListVM
    {
        public IList<DayForAllDto> Days { get; set; }

        public AllDaysListVM()
        {
            Days = new List<DayForAllDto>();
        }
    }
}
