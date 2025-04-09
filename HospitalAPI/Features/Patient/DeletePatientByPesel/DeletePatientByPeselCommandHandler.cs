using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Patient.DeletePatientByPesel
{
    public class DeletePatientByPeselCommandHandler : ICommandHandler<DeletePatientByPeselCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientByPeselCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<Result> Handle(DeletePatientByPeselCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _patientRepository.DeletePatientByPeselAsync(request.Pesel);
            _patientRepository.Dispose();
            if(affectedRows == 0)
            {
                return Result.Failure(PatientErrors.NotFound);
            }
            return Result.Success();
        }
    }
}
