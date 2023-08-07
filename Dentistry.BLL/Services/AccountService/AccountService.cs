using AutoMapper;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.DTO.UserDTO.UserDTO;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;

namespace Dentistry.BLL.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AccountService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterNewUserAsync(UserRegisterDTO registerDTO, byte[] passwordSalt)
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
    }
}
