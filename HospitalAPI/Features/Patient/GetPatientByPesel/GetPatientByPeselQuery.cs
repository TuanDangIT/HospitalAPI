using HospitalAPI.Abstractions;

namespace HospitalAPI.Features.Patient.GetPatientByPesel
{
    public sealed record class GetPatientByPeselQuery(string Pesel) : IQuery<Entities.Patient>;
}
