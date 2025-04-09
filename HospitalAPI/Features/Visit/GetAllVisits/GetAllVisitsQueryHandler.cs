using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Visit.GetAllVisits
{
    public class GetAllVisitsQueryHandler : IQueryHandler<GetAllVisitsQuery, IEnumerable<Entities.Visit>>
    {
        private readonly IVisitRepository _visitRepository;

        public GetAllVisitsQueryHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task<Result<IEnumerable<Entities.Visit>>> Handle(GetAllVisitsQuery request, CancellationToken cancellationToken)
        {
            var visits = await _visitRepository.GetAllVisitsAsync(request.Pesel); 
            return Result.Success(visits);
        }
    }
}
