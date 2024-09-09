using HealthcareRecordsAPI.DTOs;
using HealthcareRecordsAPI.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareRecordsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDisplayDto>>> GetDoctors(
            [FromQuery] string sortField = "Id",
            [FromQuery] string sortOrder = "asc",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var doctors = await _doctorService.GetDoctorsAsync(sortField, sortOrder, pageNumber, pageSize);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorEditDto>> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor([FromBody] DoctorEditDto doctorDto)
        {
            await _doctorService.AddDoctorAsync(doctorDto);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctorDto.Id }, doctorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor(int id, [FromBody] DoctorEditDto doctorDto)
        {
            if (id != doctorDto.Id)
                return BadRequest();

            await _doctorService.UpdateDoctorAsync(doctorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}
