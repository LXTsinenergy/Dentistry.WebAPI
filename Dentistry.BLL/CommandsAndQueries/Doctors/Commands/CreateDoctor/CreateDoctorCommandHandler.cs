using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Helpers;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.SpecialityRepository;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;
using MediatR;

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
                //Specialties = request.Specialties,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = hasingPassword,
                Salt = salt,
                Role = Role.doctor
            };

            try
            {
                await _doctorRepository.AddAsync(doctor, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }
    }
}
