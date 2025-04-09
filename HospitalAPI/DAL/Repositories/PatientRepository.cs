using HospitalAPI.Entities;
using System.Data;

namespace HospitalAPI.DAL.Repositories
{
    public class PatientRepository : IDisposable, IPatientRepository
    {
        private IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public PatientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(configuration.GetConnectionString("Dapper"));
        }
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            var sqlCommand = "dbo.spGetAllPatients";
            var patients = await _connection.QueryAsync<Patient>(sqlCommand
                , commandType: CommandType.StoredProcedure);
            return patients;
        }
        public async Task<Patient?> GetPatientByPeselAsync(string pesel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Pesel", pesel);
            var sqlCommand = "dbo.spGetPatientByPesel";
            var patient = await _connection.QuerySingleOrDefaultAsync<Patient>(sqlCommand, parameters
                , commandType: CommandType.StoredProcedure);
            return patient is not null ? patient : default;
        }
        public async Task<int> DeletePatientByPeselAsync(string pesel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Pesel", pesel);
            var sqlCommand = "dbo.spDeletePatientByPesel";
            var affectedRows = await _connection.ExecuteAsync(sqlCommand, parameters
                , commandType: CommandType.StoredProcedure);
            return affectedRows;
        }
        public async Task<int> InsertPatientAsync(Patient patient)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", patient.FirstName);
            parameters.Add("@LastName", patient.LastName);
            parameters.Add("@Address", patient.Address);
            parameters.Add("@Pesel", patient.Pesel);
            parameters.Add("@PhoneNumber", patient.PhoneNumber);
            var sqlCommand = "dbo.spInsertPatient";
            var affectedRows = await _connection.ExecuteAsync(sqlCommand, parameters
                , commandType: CommandType.StoredProcedure);
            return affectedRows;

        }
        public async Task<int> UpdatePatientByPeselAsync(Patient patient)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", patient.FirstName);
            parameters.Add("@LastName", patient.LastName);
            parameters.Add("@Address", patient.Address);
            parameters.Add("@Pesel", patient.Pesel);
            parameters.Add("@PhoneNumber", patient.PhoneNumber);
            var sqlCommand = "dbo.spUpdatePatientByPesel";
            var affectedRows = await _connection.ExecuteAsync(sqlCommand, parameters
                , commandType: CommandType.StoredProcedure);
            return affectedRows;
        }
        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
