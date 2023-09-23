using AutoMapper;
using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Models.Specialties.AllSpecialties;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.SpecialityRepository;
using Dentistry.Domain.Models;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Specialties.Queries.GetSpecialties
{
    public class GetAllSpecialtiesQueryHandler : IRequestHandler<GetAllSpecialtiesQuery, AllSpecialtiesListVM>
    {
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public GetAllSpecialtiesQueryHandler(ISpecialityRepository specialityRepository,
            IDoctorRepository doctorRepository,
            IMapper mapper)
        {
            _specialityRepository = specialityRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<AllSpecialtiesListVM> Handle(GetAllSpecialtiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specialties = await _specialityRepository.GetAllAsync();
                var specialtiesListVm = new AllSpecialtiesListVM();

                foreach (var speciality in specialties)
                {
                    var specialityDto = _mapper.Map<SpecialityForAllDto>(speciality);

                    var names = await GetDoctorNamesWithSpecialityAsync(speciality);
                    specialityDto.Doctors = names;
                    specialtiesListVm.Specialties.Add(specialityDto);
                }
                return specialtiesListVm;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(SpecialityRepository), ex.Message);
            }
        } 

        private async Task<List<string>> GetDoctorNamesWithSpecialityAsync(Speciality speciality)
        {
            try
            {
                var doctors = await _doctorRepository.GetAllAsync();
                var names = doctors
                    .Where(doctor => doctor.Specialties
                    .Contains(speciality))
                    .Select(doctor => doctor.Fullname)
                    .ToList();
                return names;
            }
            catch (Exception ex)
            {
                throw new RepositoryOperationException(nameof(DoctorRepository), ex.Message);
            }
        }
    }
}
