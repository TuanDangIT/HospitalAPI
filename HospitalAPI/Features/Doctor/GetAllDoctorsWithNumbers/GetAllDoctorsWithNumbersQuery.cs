using HospitalAPI.Abstractions;
using HospitalAPI.Entities;

namespace HospitalAPI.Features.Doctor.GetAllDoctorsWithNumbers
{
    public sealed record class GetAllDoctorsWithNumbersQuery : IQuery<IEnumerable<Entities.Doctor>>;
}
