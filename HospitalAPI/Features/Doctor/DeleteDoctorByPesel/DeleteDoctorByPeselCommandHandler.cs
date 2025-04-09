
using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Doctor.DeleteDoctorByPesel
{
    public class DeleteDoctorByPeselCommandHandler : ICommandHandler<DeleteDoctorByPeselCommand>
    {
        private readonly IDoctorRepository _doctorRepository;
        public DeleteDoctorByPeselCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<Result> Handle(DeleteDoctorByPeselCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _doctorRepository.DeleteDoctorByPeselAsync(request.Pesel);
            if(affectedRows == 0)
            {
                return Result.Failure(DoctorErrors.NotFound);
            }
            return Result.Success();
        }
    }
}
