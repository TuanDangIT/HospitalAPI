using HospitalAPI.Abstractions;
using HospitalAPI.Entities;

namespace HospitalAPI.Features.Visit.GetAllVisits
{
    public sealed record class GetAllVisitsQuery(string Pesel) : IQuery<IEnumerable<Entities.Visit>>;
}
