using HealthcareRecordsAPI.DTOs;
using HealthcareRecordsAPI.Models;

namespace HealthcareRecordsAPI.Intefaces
{
    public interface IPatientService
    {
        Task<PatientEditDto> GetPatientByIdAsync(int id);
        Task<IEnumerable<PatientDisplayDto>> GetPatientsAsync(string sortField, string sortOrder, int pageNumber, int pageSize);
        Task AddPatientAsync(PatientEditDto patient);
        Task UpdatePatientAsync(PatientEditDto patient);
        Task DeletePatientAsync(int id);
    }
}
