using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Helpers;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.SpecialityRepository;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;
using MediatR;
using System.Numerics;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, bool>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialityRepository _specialityRepository;

        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, ISpecialityRepository specialityRepository)
        {
            _doctorRepository = doctorRepository;
            _specialityRepository = specialityRepository;
        }

        public async Task<bool> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var salt = PasswordHelper.GenerateSalt();
            var hasingPassword = PasswordHelper.HashPassword(request.Password, salt);

            var doctor = new Doctor
            {
                Fullname = request.Fullname,
                Experience = request.Experience,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = hasingPassword,
                Salt = salt,
                Role = Role.doctor
            };

            try
            {
                var doctorSpecialties = await GetDoctorSpecialtiesAsync(request.SpecialtiesId);
                doctor.Specialties = doctorSpecialties;

                await _doctorRepository.AddAsync(doctor, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }

        private async Task<List<Speciality>> GetDoctorSpecialtiesAsync(List<int> specialtiesId)
        {
            try
            {
                var specialties = await _specialityRepository.GetAllAsync();
                var specialtiesForDoctor = specialties
                    .Where(speciality => specialtiesId
                    .Contains(speciality.Id))
                    .ToList();

                return specialtiesForDoctor;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(SpecialityRepository), ex.Message);
            }
        }
    }
}
