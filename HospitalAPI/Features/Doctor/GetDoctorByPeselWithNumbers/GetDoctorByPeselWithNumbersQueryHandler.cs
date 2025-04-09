using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Doctor.GetDoctorByPeselWithNumbers
{
    public class GetDoctorByPeselWithNumbersQueryHandler : IQueryHandler<GetDoctorByPeselWithNumbersQuery, Entities.Doctor>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorByPeselWithNumbersQueryHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<Result<Entities.Doctor>> Handle(GetDoctorByPeselWithNumbersQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetDoctorByPeselWithNumbersAsync(request.Pesel);
            if (doctor is null)
            {
                return Result.Failure<Entities.Doctor>(DoctorErrors.NotFound);
            }
            return Result.Success(doctor);
        }
    }
}
