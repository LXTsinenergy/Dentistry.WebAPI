using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Specialties.Commands.CreateSpeciality
{
    public class CreateSpecialityCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
