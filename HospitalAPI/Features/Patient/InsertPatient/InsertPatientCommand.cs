using System.Windows.Input;

namespace HospitalAPI.Features.Patient.InsertPatient
{
    public sealed record class InsertPatientCommand(string FirstName, string LastName, string Address, string Pesel, string PhoneNumber) : Abstractions.ICommand;
}
