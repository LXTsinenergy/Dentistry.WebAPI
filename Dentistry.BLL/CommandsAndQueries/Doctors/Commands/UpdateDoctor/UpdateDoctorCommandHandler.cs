using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.SpecialityRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, bool>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialityRepository _specialityRepository;

        public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, ISpecialityRepository specialityRepository)
        {
            _doctorRepository = doctorRepository;
            _specialityRepository = specialityRepository;
        }

        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            request.Doctor.Fullname = request.Fullname;
            request.Doctor.Experience = request.Experience;
            request.Doctor.Specialties = await GetSpecialtiesAsync(request.SpecialtiesId);
            request.Doctor.Email = request.Email;
            request.PhoneNumber = request.PhoneNumber;
            
            try
            {
                await _doctorRepository.UpdateAsync(request.Doctor, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }

        private async Task<List<Speciality>> GetSpecialtiesAsync(List<int> specialtiesId)
        {
            try
            {
                var specialties = await _specialityRepository.GetAllAsync();
                var idSpecialties = specialties
                    .Where(speciality => specialtiesId.Contains(speciality.Id))
                    .ToList();
                return idSpecialties;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(SpecialityRepository), ex.Message);
            }
        }
    }
}
