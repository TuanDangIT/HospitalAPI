using HospitalAPI.Entities;

namespace HospitalAPI.DAL.Repositories
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetAllVisitsAsync(string pesel);
        Task<int> DeleteVisitByPeselAsync(int id);
        Task<int> InsertVisitAsync(string patientPesel, string doctorPesel
            , int price, string typeOfVisit, string additionalInformation);
        Task<int> UpdateVisitByIdAsync(int id, string patientPesel, string doctorPesel
            , int price, string typeOfVisit, string additionalInformation);
    }
}
