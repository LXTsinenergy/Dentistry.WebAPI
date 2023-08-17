using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.SpecialityRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Specialties.Commands.CreateSpeciality
{
    public class CreateSpecialityCommandHandler : IRequestHandler<CreateSpecialityCommand, bool>
    {
        private readonly ISpecialityRepository _specialityRepository;

        public CreateSpecialityCommandHandler(ISpecialityRepository specialityRepository) =>
            _specialityRepository = specialityRepository;

        public async Task<bool> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
        {
            var speciality = new Speciality { Name = request.Name };

            try
            {
                await _specialityRepository.AddAsync(speciality, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(SpecialityRepository), ex.Message);
            }
        }
    }
}
