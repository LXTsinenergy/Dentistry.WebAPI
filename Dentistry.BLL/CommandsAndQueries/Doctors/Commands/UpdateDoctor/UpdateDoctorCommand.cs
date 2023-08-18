using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<bool>
    {
        public Doctor Doctor { get; set; }
        public string Fullname { get; set; }
        public int Experience { get; set; }
        public List<int> SpecialtiesId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
