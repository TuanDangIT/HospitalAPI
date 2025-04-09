using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Entities;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Patient.GetPatientByPesel
{
    public class GetPatientByPeselQueryHandler : IQueryHandler<GetPatientByPeselQuery, Entities.Patient>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByPeselQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<Result<Entities.Patient>> Handle(GetPatientByPeselQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientByPeselAsync(request.Pesel);
            _patientRepository.Dispose();
            if (patient == null)
            {
                return Result.Failure<Entities.Patient>(PatientErrors.NotFound);
            }
            return Result.Success(patient);
        }
    }
}
