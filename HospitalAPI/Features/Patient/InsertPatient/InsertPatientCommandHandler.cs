using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Patient.InsertPatient
{
    public class InsertPatientCommandHandler : ICommandHandler<InsertPatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public InsertPatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<Result> Handle(InsertPatientCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _patientRepository.InsertPatientAsync(new Entities.Patient()
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
                return Result.Failure(PatientErrors.CannotInsert);
            }
            return Result.Success();
        }
    }
}
