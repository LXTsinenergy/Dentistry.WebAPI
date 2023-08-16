using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.DoctorRepository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => 
            await _context.Doctors
            .Include(x => x.Notes)
            .Include(x => x.Reviews)
            .Include(x => x.Specialties)
            .ToListAsync();

        public async Task<Doctor?> GetByEmailAsync(string email) => 
            await _context.Doctors
            .Include(x => x.Notes)
            .Include(x => x.Reviews)
            .FirstOrDefaultAsync(d => d.Email == email);

        public async Task<Doctor?> GetByIdAsync(int id) => 
            await _context.Doctors
            .Include(x => x.Notes)
            .Include(x => x.Reviews)
            .FirstOrDefaultAsync(d => d.Id == id);

        public async Task<Doctor?> GetByPhoneNumberAsync(string phoneNumber) => 
            await _context.Doctors
            .Include(x => x.Notes)
            .Include(x => x.Reviews)
            .FirstOrDefaultAsync(d => d.PhoneNumber == phoneNumber);
    }
}
