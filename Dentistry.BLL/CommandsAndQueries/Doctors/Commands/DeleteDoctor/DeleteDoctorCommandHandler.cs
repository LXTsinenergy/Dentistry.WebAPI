using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.DoctorRepository;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, bool>
    {
        private readonly IDoctorRepository _doctorRepository;

        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _doctorRepository.DeleteAsync(request.Doctor, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }
    }
}
