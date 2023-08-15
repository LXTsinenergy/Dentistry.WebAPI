using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);
                return user;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(UserRepository), ex.Message);
            }
        }
    }
}
