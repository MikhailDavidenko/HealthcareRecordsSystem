using HealthcareRecordsAPI.Intefaces;
using HealthcareRecordsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareRecordsAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetById(int id) => await _context.Patients.FindAsync(id);

        public async Task<IEnumerable<Patient>> GetAll() => await _context.Patients.ToListAsync();

        public async Task Add(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Patient patient)
        {
            _context.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
