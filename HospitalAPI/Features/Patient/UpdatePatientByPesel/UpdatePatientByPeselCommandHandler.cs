using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Patient.UpdatePatientByPesel
{
    public class UpdatePatientByPeselCommandHandler : ICommandHandler<UpdatePatientByPeselCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientByPeselCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<Result> Handle(UpdatePatientByPeselCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _patientRepository.UpdatePatientByPeselAsync(new Entities.Patient()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Pesel = request.Pesel,
                PhoneNumber = request.PhoneNumber,
            });
            _patientRepository.Dispose();
            if (affectedRows == 0)
            {
                return Result.Failure(PatientErrors.CannotUpdate);
            }
            return Result.Success();
        }
    }
}
