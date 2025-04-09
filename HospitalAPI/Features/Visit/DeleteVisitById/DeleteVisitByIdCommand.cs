namespace HospitalAPI.Features.Visit.DeleteVisitById
{
    public sealed record class DeleteVisitByIdCommand(int Id) : Abstractions.ICommand;
}
