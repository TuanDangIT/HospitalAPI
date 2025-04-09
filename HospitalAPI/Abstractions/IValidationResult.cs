using HospitalAPI.Errors;

namespace HospitalAPI.Abstractions
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new("validation-error", "A validation problem occured.");
        Error[] Errors { get; }
    }
}
