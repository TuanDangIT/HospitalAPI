using HospitalAPI.Entities;

namespace HospitalAPI.DAL.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsWithNumbers();
        //Task<IEnumerable<Patient>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByPeselWithNumbersAsync(string pesel);
        Task<int> DeleteDoctorByPeselAsync(string pesel);
        Task<int> InsertDoctorAsync(Doctor doctor);
        Task<int> UpdateDoctorByPeselAsync(Doctor doctor);
        Task<int> TransactionInsertDoctorAsync(Doctor doctor);
    }
}
