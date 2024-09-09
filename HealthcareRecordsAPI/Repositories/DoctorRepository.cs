using HealthcareRecordsAPI.Intefaces;
using HealthcareRecordsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HealthcareRecordsAPI.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(string sortField, string sortOrder, int pageNumber, int pageSize)
        {
            return await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(d => d.Specialization)
                .Include(d => d.Section)
                .OrderBy($"{sortField} {sortOrder}")
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(d => d.Specialization)
                .Include(d => d.Section)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
