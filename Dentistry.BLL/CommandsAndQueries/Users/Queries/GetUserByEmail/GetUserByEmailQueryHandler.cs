using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository) =>
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(request.Email);
                return user;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(UserRepository), ex.Message);
            }
        }
    }
}
