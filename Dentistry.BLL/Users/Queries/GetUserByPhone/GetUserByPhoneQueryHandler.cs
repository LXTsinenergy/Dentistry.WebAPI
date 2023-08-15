using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.Users.Queries.GetUserByPhone
{
    public class GetUserByPhoneQueryHandler : IRequestHandler<GetUserByPhoneQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByPhoneQueryHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<User> Handle(GetUserByPhoneQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByPhoneNumberAsync(request.PhoneNumber);
                return user ?? null;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(UserRepository), ex.Message);
            }
        }
    }
}
