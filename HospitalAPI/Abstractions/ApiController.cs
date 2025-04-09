using HospitalAPI.Errors;
using HospitalAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Abstractions
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected ActionResult HandleFailure(Result result)
            => result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                IValidationResult validationResult => BadRequest(CreateProblemDetails("validation-error", StatusCodes.Status400BadRequest
                    , result.Error, validationResult.Errors)),
                _ => BadRequest()
            };


        protected static ProblemDetails CreateProblemDetails(string title, int status, Error error, Error[]? errors = null)
        {
            return new()
            {
                Title = title,
                Status = status,
                Type = error.Code,
                Detail = error.Message,
                Extensions = { { nameof(errors), errors } }
            };
        }
    }
}
