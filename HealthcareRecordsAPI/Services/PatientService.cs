using AutoMapper;
using HealthcareRecordsAPI.DTOs;
using HealthcareRecordsAPI.Intefaces;
using HealthcareRecordsAPI.Models;

namespace HealthcareRecordsAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientEditDto> GetPatientByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            return _mapper.Map<PatientEditDto>(patient);
        }

        public async Task<IEnumerable<PatientDisplayDto>> GetPatientsAsync(string sortField, string sortOrder, int pageNumber, int pageSize)
        {
            var patients =  await _repository.GetAllAsync(sortField, sortOrder, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<PatientDisplayDto>>(patients);
        }

        public async Task AddPatientAsync(PatientEditDto patientDto)
        {
            
            var patient = _mapper.Map<Patient>(patientDto);
            await _repository.AddAsync(patient);
        }

        public async Task UpdatePatientAsync(PatientEditDto patientDto)
        {
            
            var patient = _mapper.Map<Patient>(patientDto);
            await _repository.UpdateAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            
            await _repository.DeleteAsync(id);
        }
    }
}
