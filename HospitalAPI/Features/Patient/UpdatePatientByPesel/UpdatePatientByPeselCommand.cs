namespace HospitalAPI.Features.Patient.UpdatePatientByPesel
{
    public sealed record class UpdatePatientByPeselCommand(string FirstName, string LastName, string Address, string PhoneNumber, string Pesel = default!) : Abstractions.ICommand;
}
