using AutoMapper;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.DTO.User;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
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

        public async Task<bool> RegisterNewUsersAsync(RegisterUserDTO registerDTO, byte[] passwordSalt)
        {
            User user = _mapper.Map<User>(registerDTO);
            user.Role = Role.user;
            user.Salt = passwordSalt;
            
            try
            {
                await _userRepository.AddAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
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

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
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
                var user = await _userRepository.GetUserByPhoneNumberAsync(phoneNumber);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddNewUserAsync(UserDTO userDTO, byte[] passwordSalt)
        {
            User user = _mapper.Map<User>(userDTO);
            user.Salt = passwordSalt;
            user.Role = Role.user;

            try
            {
                await _userRepository.AddAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EmailIsRegistered(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(email);

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
                var user = await _userRepository.GetUserByPhoneNumberAsync(phone);

                if (user != null) return true;
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
