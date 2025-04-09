using HospitalAPI.Abstractions;

namespace HospitalAPI.Features.Doctor.InsertDoctor
{
    public record class InsertDoctorCommand(string FirstName, string LastName, string Pesel, int Year, int Month, int Day) : ICommand;
}
