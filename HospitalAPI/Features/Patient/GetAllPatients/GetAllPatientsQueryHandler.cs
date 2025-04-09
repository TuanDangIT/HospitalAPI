using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Patient.GetAllPatients
{
    public class GetAllPatientsQueryHandler : IQueryHandler<GetAllPatientsQuery, IEnumerable<Entities.Patient>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result<IEnumerable<Entities.Patient>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            _patientRepository.Dispose();
            return Result.Success(patients);
        }
    }
}
