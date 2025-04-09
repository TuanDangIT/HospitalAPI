using System.Data;

namespace HospitalAPI.Features.Patient.InsertPatient
{
    public class InsertPatientCommandValidator : AbstractValidator<InsertPatientCommand>
    {
        public InsertPatientCommandValidator()
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
            RuleFor(x => x.Pesel)
                .NotEmpty()
                .NotNull()
                .MaximumLength(12)
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
