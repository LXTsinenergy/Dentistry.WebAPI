using Dentistry.Domain.DTO;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<Doctor> AddNewDoctorAsync(DoctorDTO doctorDTO, byte[] passwordSalt);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetDoctorByEmailAsync(string email);
        Task<Doctor?> GetDoctorPhoneNumberAsync(string phoneNumber);
    }
}
