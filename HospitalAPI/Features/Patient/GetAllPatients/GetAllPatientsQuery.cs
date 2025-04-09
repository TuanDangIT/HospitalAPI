using HospitalAPI.Abstractions;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Patient.GetAllPatients
{
    public sealed record class GetAllPatientsQuery : IQuery<IEnumerable<Entities.Patient>>;
}
