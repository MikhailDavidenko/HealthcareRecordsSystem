using HealthcareRecordsAPI.Models;

namespace HealthcareRecordsAPI.Intefaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetById(int id);
        Task<IEnumerable<Patient>> GetAll();
        Task Add(Patient patient);
        Task Update(Patient patient);
        Task Delete(int id);
    }
}
