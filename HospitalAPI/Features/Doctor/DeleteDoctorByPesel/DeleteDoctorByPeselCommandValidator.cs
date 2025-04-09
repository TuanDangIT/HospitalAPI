namespace HospitalAPI.Features.Doctor.DeleteDoctorByPesel
{
    public class DeleteDoctorByPeselCommandValidator : AbstractValidator<DeleteDoctorByPeselCommand>
    {
        public DeleteDoctorByPeselCommandValidator()
        {
            RuleFor(x => x.Pesel)
                .NotEmpty()
                .NotNull()
                .MaximumLength(12)
                .MinimumLength(2);
        }
    }
}
