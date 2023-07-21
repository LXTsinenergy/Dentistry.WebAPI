using AutoMapper;
using Dentistry.DAL.Repositories.DoctorRepository;
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

        public async Task<bool> AddNewDoctorAsync(DoctorCreationDTO doctorDTO, byte[] passwordSalt)
        {
            Doctor doctor = _mapper.Map<Doctor>(doctorDTO);
            doctor.Salt = passwordSalt;
            doctor.Role = Role.doctor;

            try
            {
                await _doctorRepository.AddAsync(doctor);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteDoctorAsync(Doctor doctor)
        {
            try
            {
                await _doctorRepository.DeleteAsync(doctor);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DoctorIsExists(DoctorCreationDTO doctorDTO)
        {
            try
            {
                var doctorByPhone = await _doctorRepository.GetDoctorByPhoneNumberAsync(doctorDTO.PhoneNumber);
                var doctorByEmail = await _doctorRepository.GetDoctorByEmailAsync(doctorDTO.Email);

                if (doctorByPhone != null || doctorByEmail != null) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DoctorIsExists(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

                if (doctor != null) return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DoctorIsExists(Doctor doctor)
        {
            try
            {
                if (doctor == null) return false;

                var possibleDoctor = await _doctorRepository.GetDoctorByIdAsync(doctor.Id);

                if (possibleDoctor != null) return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            try
            {
                var doctors = await _doctorRepository.GetAllAsync();
                return doctors;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor?> GetDoctorByEmailAsync(string email)
        {
            try
            {
                var doctor = await _doctorRepository.GetDoctorByEmailAsync(email);
                return doctor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
                return doctor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor?> GetDoctorPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var doctor = await _doctorRepository.GetDoctorByPhoneNumberAsync(phoneNumber);
                return doctor;
            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
