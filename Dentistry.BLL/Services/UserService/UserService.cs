using AutoMapper;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.DTO.User;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #region CRUD
        public async Task<bool> CreateUserAsync(UserDTO userDTO, byte[] passwordSalt)
        {
            try
            {
                User user = _mapper.Map<User>(userDTO);
                user.Salt = passwordSalt;
                user.Role = Role.user;

                await _userRepository.AddAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User user, UserUpdateDTO updateDTO)
        {
            try
            {
                user = MapUserUpdateData(user, updateDTO);
                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private User MapUserUpdateData(User user, UserUpdateDTO updateDTO)
        {
            if (updateDTO.Name != null) user.Name = updateDTO.Name;
            if (updateDTO.Email != null) user.Email = updateDTO.Email;
            if (updateDTO.PhoneNumber != null) user.PhoneNumber = updateDTO.PhoneNumber;

            return user;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            try
            {
                await _userRepository.DeleteAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        } 
        #endregion

        #region Get
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users;
            }
            catch
            {
                return Enumerable.Empty<User>();
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(email);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var user = await _userRepository.GetByPhoneNumberAsync(phoneNumber);
                return user;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Registered
        public async Task<bool> EmailIsRegistered(string email)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(email);

                if (user != null) return true;
                return false;
            }
            catch
            {
                return true;
            }
        }

        public async Task<bool> PhoneIsRegistered(string phone)
        {
            try
            {
                var user = await _userRepository.GetByPhoneNumberAsync(phone);

                if (user != null) return true;
                return false;
            }
            catch
            {
                return true;
            }
        } 
        #endregion

        #region IsExists
        public async Task<bool> UserIsExists(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user != null) return true;
                return false;
            }
            catch
            {
                return true;
            }
        }
        #endregion

        #region Password
        public async Task<bool> UpdateUserPasswordAsync(User user, string password)
        {
            try
            {
                user.Password = password;

                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        } 
        #endregion
    }
}
