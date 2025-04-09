using HospitalAPI.Shared;

namespace HospitalAPI.Abstractions
{
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
    public interface ICommand : IRequest<Result>
    {
    }
}
