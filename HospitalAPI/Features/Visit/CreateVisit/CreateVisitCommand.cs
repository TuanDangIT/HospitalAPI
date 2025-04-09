using System.Windows.Input;

namespace HospitalAPI.Features.Visit.CreateVisit
{
    public sealed record class CreateVisitCommand(string PatientPesel, string DoctorPesel
        , int Price, string TypeOfVisit, string AdditionalInformation ) : Abstractions.ICommand;
}
