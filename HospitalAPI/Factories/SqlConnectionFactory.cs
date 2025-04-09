using System.Data;
using System.Data.Common;

namespace HospitalAPI.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private string _connectionString;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Dapper")
                ?? throw new ApplicationException("Connection string is missing");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
