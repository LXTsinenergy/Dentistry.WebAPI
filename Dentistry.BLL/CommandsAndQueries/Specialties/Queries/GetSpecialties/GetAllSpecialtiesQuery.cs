using Dentistry.BLL.Models.AllSpecialties;
using MediatR;

namespace Dentistry.BLL.CommandsAndQueries.Specialties.Queries.GetSpecialties
{
    public class GetAllSpecialtiesQuery : IRequest<AllSpecialtiesListVM>
    {
    }
}
