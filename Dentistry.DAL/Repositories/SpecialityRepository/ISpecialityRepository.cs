using Dentistry.Domain.Models;

namespace Dentistry.DAL.Repositories.SpecialityRepository
{
    public interface ISpecialityRepository
    {
        Task<IEnumerable<Speciality>> GetAllAsync();
        Task<Speciality> GetByIdAsync(int id);
        Task AddAsync(Speciality speciality, CancellationToken cancellationToken);
        Task UpdateAsync(Speciality speciality, CancellationToken cancellationToken);
        Task DeleteAsync(Speciality speciality, CancellationToken cancellationToken);
    }
}
