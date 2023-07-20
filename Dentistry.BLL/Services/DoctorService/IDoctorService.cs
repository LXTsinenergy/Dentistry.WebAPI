using Dentistry.Domain.DTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<bool> AddNewDoctorAsync(DoctorDTO doctorDTO, byte[] passwordSalt);
        Task<bool> DeleteDoctorAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetDoctorByEmailAsync(string email);
        Task<Doctor?> GetDoctorPhoneNumberAsync(string phoneNumber);
        Task<Doctor?> GetDoctorByIdAsync(int id);
        Task<bool> DoctorIsExists(DoctorDTO doctorDTO);
        Task<bool> DoctorIsExists(Doctor doctor);
        Task<bool> DoctorIsExists(int id);
    }
}
