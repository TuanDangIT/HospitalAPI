using HospitalAPI.Entities;

namespace HospitalAPI.DAL.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient?> GetPatientByPeselAsync(string pesel);
        Task<int> DeletePatientByPeselAsync(string pesel);
        Task<int> InsertPatientAsync(Patient patient);
        Task<int> UpdatePatientByPeselAsync(Patient patient);
        void Dispose();
    }
}
