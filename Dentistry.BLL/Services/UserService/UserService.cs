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

        public async Task<User> RegisterNewUsersAsync(RegisterUserDTO registerDTO, byte[] passwordSalt)
        {
            User user = _mapper.Map<User>(registerDTO);
            user.Role = Role.user;
            user.Salt = passwordSalt;
            
            try
            {
                await _userRepository.AddAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(email);
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var user = await _userRepository.GetUserByPhoneNumberAsync(phoneNumber);
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> AddNewUserAsync(UserDTO userDTO, byte[] passwordSalt)
        {
            User user = _mapper.Map<User>(userDTO);
            user.Salt = passwordSalt;
            user.Role = Role.user;

            try
            {
                await _userRepository.AddAsync(user);
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
