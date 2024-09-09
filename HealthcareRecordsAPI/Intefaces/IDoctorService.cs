using HealthcareRecordsAPI.DTOs;

namespace HealthcareRecordsAPI.Intefaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDisplayDto>> GetDoctorsAsync(string sortField, string sortOrder, int pageNumber, int pageSize);
        Task<DoctorEditDto> GetDoctorByIdAsync(int id);
        Task AddDoctorAsync(DoctorEditDto doctorDto);
        Task UpdateDoctorAsync(DoctorEditDto doctorDto);
        Task DeleteDoctorAsync(int id);
    }
}
