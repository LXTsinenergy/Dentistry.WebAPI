namespace Dentistry.BLL.Models.Doctor.DoctorForAll
{
    public class AllDoctorsListVM
    {
        public IList<DoctorForAllDto> Doctors {  get; set; }

        public AllDoctorsListVM()
        {
            Doctors = new List<DoctorForAllDto>();
        }
    }
}
