using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Visit.DeleteVisitById
{
    public class DeleteVisitByIdCommandHandler : ICommandHandler<DeleteVisitByIdCommand>
    {
        private readonly IVisitRepository _visitRepository;

        public DeleteVisitByIdCommandHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task<Result> Handle(DeleteVisitByIdCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _visitRepository.DeleteVisitByPeselAsync(request.Id);
            if(affectedRows == 0)
            {
                return Result.Failure(VisitErrors.NotFound);
            }
            return Result.Success();
        }
    }
}
