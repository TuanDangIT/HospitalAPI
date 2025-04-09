namespace HospitalAPI.Features.Patient.DeletePatientByPesel
{
    public sealed class DeletePatientByPeselCommandValidator : AbstractValidator<DeletePatientByPeselCommand>
    {
        public DeletePatientByPeselCommandValidator()
        {
            RuleFor(x => x.Pesel)
                .NotEmpty()
                .NotNull()
                .MaximumLength(12)
                .MinimumLength(2);
        }
    }
}
