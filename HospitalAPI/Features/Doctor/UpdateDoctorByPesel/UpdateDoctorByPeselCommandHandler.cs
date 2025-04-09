using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Doctor.UpdateDoctorByPesel
{
    public class UpdateDoctorByPeselCommandHandler : ICommandHandler<UpdateDoctorByPeselCommand>
    {
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorByPeselCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<Result> Handle(UpdateDoctorByPeselCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _doctorRepository.UpdateDoctorByPeselAsync(new Entities.Doctor()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Pesel = request.Pesel,
                DateOfHire = new DateTime(request.Year, request.Month, request.Day),
            });
            if (affectedRows == 0)
            {
                Result.Failure(DoctorErrors.CannotUpdate);
            }
            return Result.Success();
        }
    }
}
