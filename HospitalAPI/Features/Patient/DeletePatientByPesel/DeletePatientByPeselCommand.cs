using System.Windows.Input;

namespace HospitalAPI.Features.Patient.DeletePatientByPesel
{
    public sealed record class DeletePatientByPeselCommand(string Pesel) : Abstractions.ICommand;
}
