namespace HospitalAPI.Features.Visit.DeleteVisitById
{
    public class DeleteVisitByIdCommandValidator : AbstractValidator<DeleteVisitByIdCommand>
    {
        public DeleteVisitByIdCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
