using HospitalAPI.Shared;

namespace HospitalAPI.Abstractions
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
