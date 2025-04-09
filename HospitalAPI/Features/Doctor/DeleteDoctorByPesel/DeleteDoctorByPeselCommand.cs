using HospitalAPI.Abstractions;

namespace HospitalAPI.Features.Doctor.DeleteDoctorByPesel
{
    public sealed record class DeleteDoctorByPeselCommand(string Pesel) : ICommand;
}
