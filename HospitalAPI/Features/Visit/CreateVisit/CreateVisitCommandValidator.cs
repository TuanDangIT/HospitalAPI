namespace HospitalAPI.Features.Visit.CreateVisit
{
    public class CreateVisitCommandValidator : AbstractValidator<CreateVisitCommand>
    {
        public CreateVisitCommandValidator()
        {
            RuleFor(x => x.DoctorPesel)
                .NotEmpty()
                .NotNull()
                .MaximumLength(12)
                .MinimumLength(2);
            RuleFor(x => x.PatientPesel)
                .NotEmpty()
                .NotNull()
                .MaximumLength(12)
                .MinimumLength(2);
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.TypeOfVisit)
                .NotEmpty()
                .NotNull()
                .Custom((value, context) =>
                {
                    List<string> typeOfVisits = new List<string>() { "Badania", "Zabieg", "Konsultacje"};
                    if (!typeOfVisits.Contains(value)) context.AddFailure("Type of visit should be included in given list: {Badania, Zabieg, Konsultacje}");
                })
                .MaximumLength(15);
            RuleFor(x => x.AdditionalInformation)
                .MaximumLength(50);
        }
    }
}
