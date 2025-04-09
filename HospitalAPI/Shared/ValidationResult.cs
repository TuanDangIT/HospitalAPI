using HospitalAPI.Abstractions;
using HospitalAPI.Errors;

namespace HospitalAPI.Shared
{
    public class ValidationResult : Result, IValidationResult
    {
        public ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }
        public Error[] Errors { get; }
        public static ValidationResult WithErrors(Error[] errors) => new ValidationResult(errors);
    }
    public class ValidationResult<T> : Result<T>, IValidationResult
    {
        public ValidationResult(Error[] errors) : base(default!, false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }
        public Error[] Errors { get; }
        public static ValidationResult<T> WithErrors(Error[] errors) => new ValidationResult<T>(errors);
    }
}
