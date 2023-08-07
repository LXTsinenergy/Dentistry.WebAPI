using AutoMapper;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.Domain.DTO.Doctor;
using Dentistry.Domain.DTO.DoctorDTO;
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

        #region CRUD
        public async Task<bool> CreateDoctorAsync(DoctorCreationDTO doctorDTO, byte[] passwordSalt)
        {
            try
            {
                Doctor doctor = _mapper.Map<Doctor>(doctorDTO);
                doctor.Salt = passwordSalt;
                doctor.Role = Role.doctor;

                await _doctorRepository.AddAsync(doctor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDoctorAsync(Doctor doctor)
        {
            try
            {
                await _doctorRepository.DeleteAsync(doctor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateDoctorAsync(Doctor doctor, DoctorUpdateDTO updateDTO)
        {
            try
            {
                doctor = MapDoctorUpdateData(doctor, updateDTO);
                await _doctorRepository.UpdateAsync(doctor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Doctor MapDoctorUpdateData(Doctor doctor, DoctorUpdateDTO updateDTO)
        {
            if (updateDTO.Fullname != null) doctor.Fullname = updateDTO.Fullname;
            if (updateDTO.Experience != 0) doctor.Experience = updateDTO.Experience;
            if (updateDTO.Specialties != null) doctor.Specialties = updateDTO.Specialties;
            if (updateDTO.Email != null) doctor.Email = updateDTO.Email;
            if (updateDTO.PhoneNumber != null) doctor.PhoneNumber = updateDTO.PhoneNumber;

            return doctor;
        } 
        #endregion

        #region Registered
        public async Task<bool> PhoneIsRegistered(string phoneNumber)
        {
            try
            {
                var doctor = await _doctorRepository.GetByPhoneNumberAsync(phoneNumber);

                if (doctor != null) return true;
                return false;
            }
            catch
            {
                return true;
            }
        }

        public async Task<bool> EmailIsRegistered(string email)
        {
            try
            {
                var doctor = await _doctorRepository.GetByEmailAsync(email);

                if (doctor != null) return true;
                return false;
            }
            catch
            {
                return true;
            }
        } 
        #endregion

        #region DoctorIsExists
        public async Task<bool> DoctorIsExists(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetByIdAsync(id);

                if (doctor != null) return true;
                return false;
            }
            catch
            {
                return true;
            }
        }
        #endregion

        #region Get
        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            try
            {
                var doctors = await _doctorRepository.GetAllAsync();
                return doctors;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetByIdAsync(id);
                return doctor;
            }
            catch
            {
                return null;
            }
        } 
        #endregion
    }
}
