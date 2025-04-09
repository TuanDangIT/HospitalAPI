namespace HospitalAPI.Features.Patient.UpdatePatientByPesel
{
    public class UpdatePatientByPeselCommandValidator : AbstractValidator<UpdatePatientByPeselCommand>
    {
        public UpdatePatientByPeselCommandValidator()
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
            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2); ;
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .MinimumLength(9);
        }
    }
}
