using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Helpers;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Enums;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var salt = PasswordHelper.GenerateSalt();
            var hashingPassword = PasswordHelper.HashPassword(request.Password, salt);

            var user = new User
            {
                Fullname = request.Fullname,
                Email = request.Email,
                Password = hashingPassword,
                Salt = salt,
                PhoneNumber = request.PhoneNumber,
                Role = Role.user
            };

            try
            {
                await _userRepository.AddAsync(user, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(UserRepository), ex.Message);
            }
        }
    }
}
