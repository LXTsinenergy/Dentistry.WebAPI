using Dentistry.BLL.Models.Doctor.DoctorForAll;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQuery : IRequest<AllDoctorsListVM>
    {
    }
}
