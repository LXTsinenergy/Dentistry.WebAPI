using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository) =>
            _doctorRepository = doctorRepository;

        public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _doctorRepository.GetByIdAsync(request.Id);
                return doctor;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }
    }
}
