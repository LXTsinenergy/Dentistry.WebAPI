using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository ?? throw new NullReferenceException(nameof(UserRepository));

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            user.Fullname = request.Fullname;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;

            try
            {
                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch
            {
                throw new EntityDbOperationException(user, nameof(UserRepository));
            }
        }
    }
}
