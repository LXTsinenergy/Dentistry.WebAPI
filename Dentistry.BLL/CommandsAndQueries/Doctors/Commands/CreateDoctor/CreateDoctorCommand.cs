using Dentistry.Domain.Enums;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<bool>
    {
        public string Fullname { get; set; }
        public int Experience { get; set; }
        public List<int> SpecialtiesId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
