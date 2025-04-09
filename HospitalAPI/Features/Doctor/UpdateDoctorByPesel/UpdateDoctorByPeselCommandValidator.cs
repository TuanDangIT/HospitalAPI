namespace HospitalAPI.Features.Doctor.UpdateDoctorByPesel
{
    public class UpdateDoctorByPeselCommandValidator : AbstractValidator<UpdateDoctorByPeselCommand>
    {
        public UpdateDoctorByPeselCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(10)
                .MinimumLength(2);
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(10)
                .MinimumLength(2);
            RuleFor(x => x.Year)
                .NotEmpty()
                .NotEqual(0)
                .Custom((value, context) =>
                {
                    if (value < 1999)
                    {
                        context.AddFailure("DateOfHire", "The date is wrong and should be above 1999");
                    }
                });
            RuleFor(x => x.Day)
                .NotEmpty()
                .NotEqual(0)
                .Must(x => x > 0 && x <= 31).WithMessage("Date should be between 1 and 31");
            RuleFor(x => x.Month)
                .NotEmpty()
                .NotEqual(0)
                .Must(x => x > 0 && x <= 12).WithMessage("Date should be between 1 and 12");
        }
    }
}
