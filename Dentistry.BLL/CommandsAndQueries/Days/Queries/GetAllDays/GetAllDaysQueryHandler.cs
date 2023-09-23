using AutoMapper;
using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Models.Day.AllDaysList;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.DAL.Repositories.NoteRepository;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Days.Queries.GetAllDays
{
    public class GetAllDaysQueryHandler : IRequestHandler<GetAllDaysQuery, AllDaysListVM>
    {
        private readonly IDayRepository _dayRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public GetAllDaysQueryHandler(IDayRepository dayRepository, INoteRepository noteRepository, IMapper mapper)
        {
            _dayRepository = dayRepository;
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<AllDaysListVM> Handle(GetAllDaysQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var days = await _dayRepository.GetAllAsync();
                var daysListVM = new AllDaysListVM();

                foreach ( var day in days)
                {
                    var dayVM = _mapper.Map<DayForAllDto>(day);
                    daysListVM.Days.Add(dayVM);
                }
                return daysListVM;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DayRepository), ex.Message);
            }
        }
    }
}
