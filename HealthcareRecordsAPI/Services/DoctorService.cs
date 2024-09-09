using AutoMapper;
using HealthcareRecordsAPI.DTOs;
using HealthcareRecordsAPI.Intefaces;
using HealthcareRecordsAPI.Models;

namespace HealthcareRecordsAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDisplayDto>> GetDoctorsAsync(string sortField, string sortOrder, int pageNumber, int pageSize)
        {
            var doctors = await _doctorRepository.GetDoctorsAsync(sortField, sortOrder, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<DoctorDisplayDto>>(doctors);
        }

        public async Task<DoctorEditDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            return _mapper.Map<DoctorEditDto>(doctor);
        }

        public async Task AddDoctorAsync(DoctorEditDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.AddDoctorAsync(doctor);
        }

        public async Task UpdateDoctorAsync(DoctorEditDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.UpdateDoctorAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
        }
    }
}
