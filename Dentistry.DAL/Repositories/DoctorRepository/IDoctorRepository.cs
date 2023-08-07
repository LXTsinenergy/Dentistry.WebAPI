using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DoctorRepository
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByPhoneNumberAsync(string phoneNumber);
        Task<Doctor?> GetByEmailAsync(string email);
        Task<Doctor?> GetByIdAsync(int id);
    }
}
