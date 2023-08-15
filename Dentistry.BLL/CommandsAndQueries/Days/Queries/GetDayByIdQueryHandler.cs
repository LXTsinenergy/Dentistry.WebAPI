using Dentistry.BLL.Exceptions;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Days.Queries
{
    public class GetDayByIdQueryHandler : IRequestHandler<GetDayByIdQuery, Workday>
    {
        private readonly IDayRepository _dayRepository;

        public GetDayByIdQueryHandler(IDayRepository dayRepository) => 
            _dayRepository = dayRepository;

        public async Task<Workday> Handle(GetDayByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var day = await _dayRepository.GetByIdAsync(request.Id);
                return day;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DayRepository), ex.Message);
            }
        }
    }
}
