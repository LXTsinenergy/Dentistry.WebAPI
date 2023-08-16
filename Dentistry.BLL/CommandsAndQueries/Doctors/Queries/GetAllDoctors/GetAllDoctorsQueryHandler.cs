using AutoMapper;
using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Models.Doctor.DoctorForAll;
using Dentistry.DAL.Repositories.DoctorRepository;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, AllDoctorsListVM>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<AllDoctorsListVM> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var doctors = await _doctorRepository.GetAllAsync();
                var doctorsListVM = new AllDoctorsListVM();

                if (doctors != null)
                {
                    foreach (var doctor in doctors)
                    {
                        var doctorForVM = _mapper.Map<DoctorForAllDto>(doctor);
                        doctorsListVM.Doctors.Add(doctorForVM);
                    }
                }
                return doctorsListVM;
            }
            catch (Exception ex) 
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }
    }
}
