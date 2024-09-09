using HealthcareRecordsAPI.Models;

namespace HealthcareRecordsAPI.Intefaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllAsync(string sortField, string sortOrder, int pageNumber, int pageSize);
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    }
}
