﻿using Dentistry.Domain.DTO.User;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserDTO userDTO, byte[] passwordSalt);
        Task<bool> UpdateUserAsync(User user, UserUpdateDTO updateDTO);
        Task<bool> DeleteUserAsync(User user);

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByPhoneNumberAsync(string phoneNumber);

        Task<bool> EmailIsRegistered(string email);
        Task<bool> PhoneIsRegistered(string phone);
        Task<bool> UserIsExists(int id);

        Task<bool> UpdateUserPasswordAsync(User user, string password);
    }
}
