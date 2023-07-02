using AutoMapper;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.Domain.DTO;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<Doctor> AddNewDoctorAsync(DoctorDTO doctorDTO, byte[] passwordSalt)
        {
            Doctor doctor = _mapper.Map<Doctor>(doctorDTO);
            doctor.Salt = passwordSalt;
            doctor.Role = Role.doctor;

            await _doctorRepository.AddAsync(doctor);

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();

            return doctors;
        }
    }
}
