using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest<bool>
    {
        public Doctor Doctor { get; set; }
    }
}
