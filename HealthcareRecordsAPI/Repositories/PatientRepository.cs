using HealthcareRecordsAPI.Intefaces;
using HealthcareRecordsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HealthcareRecordsAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.Include(p => p.Section)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(string sortField, string sortOrder, int pageNumber, int pageSize)
        {
            var query = await _context.Patients
        .Include(p => p.Section)
        .OrderBy($"{sortField} {sortOrder}")
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

            

            return query;
        }

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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
