using System.Data;

namespace HospitalAPI.Factories
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}