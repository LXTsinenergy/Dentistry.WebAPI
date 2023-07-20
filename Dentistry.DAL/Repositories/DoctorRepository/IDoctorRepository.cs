using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DoctorRepository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task AddAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
        Task<Doctor?> GetDoctorByPhoneNumberAsync(string phoneNumber);
        Task<Doctor?> GetDoctorByEmailAsync(string email);
        Task<Doctor?> GetDoctorByIdAsync(int id);
    }
}
