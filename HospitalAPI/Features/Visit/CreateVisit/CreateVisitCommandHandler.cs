using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Visit.CreateVisit
{
    public class CreateVisitCommandHandler : ICommandHandler<CreateVisitCommand>
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public CreateVisitCommandHandler(IVisitRepository visitRepository, IPatientRepository patientRepository
            , IDoctorRepository doctorRepository)
        {
            _visitRepository = visitRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientByPeselAsync(request.PatientPesel);
            if (patient == null)
            {
                return Result.Failure(PatientErrors.NotFound);
            }
            var doctor = await _doctorRepository.GetDoctorByPeselWithNumbersAsync(request.DoctorPesel);
            if (doctor == null)
            {
                return Result.Failure(DoctorErrors.NotFound);
            }
            var affectedRows = await _visitRepository.InsertVisitAsync(request.PatientPesel,
                request.DoctorPesel,
                request.Price,
                request.TypeOfVisit,
                request.AdditionalInformation);
            if(affectedRows == 0)
            {
                Result.Failure(VisitErrors.CannotInsert);
            }
            return Result.Success();
        }
    }
}
