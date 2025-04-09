using HospitalAPI.Abstractions;

namespace HospitalAPI.Features.Doctor.GetDoctorByPeselWithNumbers
{
    public sealed record class GetDoctorByPeselWithNumbersQuery(string Pesel) : IQuery<Entities.Doctor>;
}
