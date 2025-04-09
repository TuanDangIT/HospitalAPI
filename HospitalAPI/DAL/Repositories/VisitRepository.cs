using HospitalAPI.Entities;
using HospitalAPI.Factories;

namespace HospitalAPI.DAL.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public VisitRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<IEnumerable<Visit>> GetAllVisitsAsync(string pesel)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sqlCommand = "spGetAllVisitsWithPeselFilter";
            var visits = await connection.QueryAsync<Visit>(sqlCommand, new {Pesel = pesel}
                , commandType: System.Data.CommandType.StoredProcedure);
            return visits;
        }
        public async Task<int> DeleteVisitByPeselAsync(int id)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sqlCommand = "spDeleteVisitById";
            var affectedRows = await connection.ExecuteAsync(sqlCommand
                , new { Id = id }
                , commandType: System.Data.CommandType.StoredProcedure);
            return affectedRows;
        }
        public async Task<int> InsertVisitAsync(string patientPesel, string doctorPesel
            , int price, string typeOfVisit, string additionalInformation)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sqlCommand = "spInsertVisit";
            var affectedRows = await connection.ExecuteAsync(sqlCommand
                , new { PatientPesel = patientPesel,
                DoctorPesel = doctorPesel,
                Price = price,
                TypeOfVisit = typeOfVisit,
                AdditionalInformation = additionalInformation}
                , commandType: System.Data.CommandType.StoredProcedure);
            return affectedRows;
        }
        public async Task<int> UpdateVisitByIdAsync(int id, string patientPesel, string doctorPesel
            , int price, string typeOfVisit, string additionalInformation)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sqlCommand = "spUpdateVisitById";
            var affectedRows = await connection.ExecuteAsync(sqlCommand
                , new
                {
                    Id = id,
                    PatientPesel = patientPesel,
                    DoctorPesel = doctorPesel,
                    Price = price,
                    TypeOfVisit = typeOfVisit,
                    AdditionalInformation = additionalInformation
                }
                , commandType: System.Data.CommandType.StoredProcedure);
            return affectedRows;
        }
    }
}
