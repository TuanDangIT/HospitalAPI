using HospitalAPI.Abstractions;

namespace HospitalAPI.Features.Doctor.UpdateDoctorByPesel
{
    public sealed record class UpdateDoctorByPeselCommand(string FirstName, string LastName, int Year, int Month, int Day, string Pesel = default!) : ICommand;
}
