using HealthcareRecordsAPI.Models;

namespace HealthcareRecordsAPI.Intefaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync(string sortField, string sortOrder, int pageNumber, int pageSize);
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task AddDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
    }
}
