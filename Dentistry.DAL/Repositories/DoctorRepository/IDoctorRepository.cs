using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.DoctorRepository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task AddAsync(Doctor doctor);
    }
}
