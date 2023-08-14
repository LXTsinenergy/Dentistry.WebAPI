using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        
        public DeleteUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository ?? throw new NullReferenceException(nameof(UserRepository));

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);

                if (user == null)
                {
                    throw new NotFoundException(nameof(User), request.Id);
                }

                await _userRepository.DeleteAsync(user);
                return true;
            }
            catch
            {
                throw new RepositoryOperationException(nameof(UserRepository));
            }
        }
    }
}
