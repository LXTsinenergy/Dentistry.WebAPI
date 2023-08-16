﻿using Dentistry.DAL.DataContext;
using Dentistry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.DAL.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }


        public async Task<IEnumerable<User>> GetAllAsync() => 
            await _context.Users
            .ToListAsync();

        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber) => 
            await _context.Users
            .FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
    }
}
