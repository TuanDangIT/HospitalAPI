using System.Windows.Input;

namespace HospitalAPI.Features.Visit.UpdateVisitById
{
    public sealed record class UpdateVisitByIdCommand(int Id, string PatientPesel, string DoctorPesel
        , int Price, string TypeOfVisit, string AdditionalInformation) : Abstractions.ICommand;
}
