namespace Dentistry.BLL.Models.Schedule
{
    public class GetDayScheduleDto
    {
        public DateOnly Date { get; set; }
        public int DoctorId { get; set; }
    }
}
