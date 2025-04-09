using HospitalAPI.Entities;
using HospitalAPI.Factories;
using System.Data.Common;
using System.Data;

namespace HospitalAPI.DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public DoctorRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<int> DeleteDoctorByPeselAsync(string pesel)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sqlCommand = $"DELETE FROM Doctor WHERE Doctor.Pesel = @Pesel;";
            var parameters = new DynamicParameters();
            parameters.Add("@Pesel", pesel);
            var affectedRows = await connection.ExecuteAsync(sqlCommand, param: parameters
                /*, commandType: CommandType.StoredProcedure*/);
            return affectedRows;
        }

        public async Task<int> TransactionDeleteDoctorByPeselAsync(string pesel)
        {
            int affectedRows = 0;
            using var connection = _sqlConnectionFactory.CreateConnection();
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var sqlCommand = $"DELETE FROM Doctor WHERE Doctor.Pesel = @Pesel;";
                    var parameters = new DynamicParameters();
                    parameters.Add("@Pesel", pesel);
                    affectedRows = await connection.ExecuteAsync(sqlCommand, param: parameters
                        /*, commandType: CommandType.StoredProcedure*/);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            };
            return affectedRows;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsWithNumbers()
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            string sqlCommand ="spGetDoctorByPeselWithNumbers";
            Dictionary<string, Doctor> doctorDictionary = new();
            var result = await connection.QueryAsync<Doctor, Number, Doctor>(sqlCommand
                , (doctor, number) =>
                {
                    if(doctorDictionary.TryGetValue(doctor.Pesel, out var existingDoctor))
                    {
                        doctor = existingDoctor;
                    }
                    else
                    {
                        doctorDictionary.Add(doctor.Pesel, doctor);
                    }
                    doctor.PhoneNumbers.Add(number);
                    return doctor;
                }, splitOn: "PhoneNumber"
                , commandType: System.Data.CommandType.StoredProcedure);

            var doctors = result.Distinct().ToList();
            return doctors; 
        }

        public async Task<Doctor?> GetDoctorByPeselWithNumbersAsync(string pesel)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            string sqlCommand1 = "spGetDoctorByPesel";
            string sqlCommand2 = "spGetPhoneNumberByDoctorsPesel";
            var parameters = new DynamicParameters();
            parameters.Add("@Pesel", pesel);
            var doctor = await connection.QuerySingleAsync<Doctor>(sqlCommand1
                , new {Pesel = pesel}
                , commandType: System.Data.CommandType.StoredProcedure);
            if(doctor is null)
            {
                return null;
            }
            var phoneNumbers = await connection.QueryAsync<Number>(sqlCommand2
                , parameters
                , commandType: System.Data.CommandType.StoredProcedure);
            doctor.PhoneNumbers = phoneNumbers.ToList();
            return doctor;
        }

        public async Task<int> InsertDoctorAsync(Doctor doctor)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sqlCommand = "dbo.spInsertDoctor";
            var affectedRows = await connection.ExecuteAsync(sqlCommand
                , new { FirstName = doctor.FirstName, LastName = doctor.LastName, Pesel = doctor.Pesel, DateOfHire = doctor.DateOfHire }
                , commandType: CommandType.StoredProcedure);
            return affectedRows;
        }
        public async Task<int> TransactionInsertDoctorAsync(Doctor doctor)
        {
            int affectedRows = 0;
            using (var connection = new SqlConnection("server=DESKTOP-8BM3D0H\\SQLEXPRESS;database=HospitalDb;integrated security=true; TrustServerCertificate=True;Trusted_Connection=True;"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sqlCommand = "dbo.spInsertDoctor";
                        affectedRows =  await connection.ExecuteAsync(sqlCommand
                            , new { FirstName = doctor.FirstName, LastName = doctor.LastName, Pesel = doctor.Pesel, DateOfHire = doctor.DateOfHire }
                            , transaction
                            , commandType: CommandType.StoredProcedure);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                };
                
            }

                return affectedRows;
        }


        public async Task<int> UpdateDoctorByPeselAsync(Doctor doctor)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sqlCommand = "dbo.spUpdateDoctorByPesel";
            var affectedRows = await connection.ExecuteAsync(sqlCommand
                , new { FirstName = doctor.FirstName, LastName = doctor.LastName, Pesel = doctor.Pesel, DateOfHire = doctor.DateOfHire }
                , commandType: CommandType.StoredProcedure);
            return affectedRows;
        }
    }
}
