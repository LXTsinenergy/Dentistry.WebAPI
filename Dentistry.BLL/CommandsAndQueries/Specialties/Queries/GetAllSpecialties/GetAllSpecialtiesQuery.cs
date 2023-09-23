using Dentistry.BLL.Models.Specialties.AllSpecialties;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Specialties.Queries.GetSpecialties
{
    public class GetAllSpecialtiesQuery : IRequest<AllSpecialtiesListVM>
    {
    }
}
