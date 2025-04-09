using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Errors;
using HospitalAPI.Shared;

namespace HospitalAPI.Features.Doctor.InsertDoctor
{
    public class InsertDoctorCommandHandler : ICommandHandler<InsertDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;

        public InsertDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<Result> Handle(InsertDoctorCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _doctorRepository.TransactionInsertDoctorAsync(new Entities.Doctor()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Pesel = request.Pesel,
                //Tamto jak ustawialiśmy w Command DateTime zamiast int year itd. działało.
                DateOfHire = new DateTime(request.Year, request.Month, request.Day),
            });
            if(affectedRows == 0)
            {
                return Result.Failure(DoctorErrors.CannotInsert);
            }
            return Result.Success();
        }
    }
}
