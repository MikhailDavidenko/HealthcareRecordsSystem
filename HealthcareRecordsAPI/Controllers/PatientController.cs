using HealthcareRecordsAPI.DTOs;
using HealthcareRecordsAPI.Intefaces;
using HealthcareRecordsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareRecordsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDisplayDto>>> GetPatients(
        [FromQuery] string sortField = "Id",
        [FromQuery] string sortOrder = "asc",
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            var patients = await _patientService.GetPatientsAsync(sortField, sortOrder, pageNumber, pageSize);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientEditDto>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient([FromBody] PatientEditDto patientDto)
        {
            await _patientService.AddPatientAsync(patientDto);
            return CreatedAtAction(nameof(GetPatient), new { id = patientDto.Id }, patientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, [FromBody] PatientEditDto patientDto)
        {
            if (id != patientDto.Id)
                return BadRequest();

            await _patientService.UpdatePatientAsync(patientDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
