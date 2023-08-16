using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DoctorRepository
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor, CancellationToken cancellationToken);
        Task DeleteAsync(Doctor doctor, CancellationToken cancellationToken);
        Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByPhoneNumberAsync(string phoneNumber);
        Task<Doctor?> GetByEmailAsync(string email);
        Task<Doctor?> GetByIdAsync(int id);
    }
}
