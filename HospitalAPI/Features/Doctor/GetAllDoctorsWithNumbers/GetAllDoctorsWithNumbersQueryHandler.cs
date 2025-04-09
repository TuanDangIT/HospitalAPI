using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Doctor.GetAllDoctorsWithNumbers
{
    public class GetAllDoctorsWithNumbersQueryHandler : IQueryHandler<GetAllDoctorsWithNumbersQuery, IEnumerable<Entities.Doctor>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetAllDoctorsWithNumbersQueryHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<Result<IEnumerable<Entities.Doctor>>> Handle(GetAllDoctorsWithNumbersQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllDoctorsWithNumbers();
            return Result.Success(doctors);
        }
    }
}
