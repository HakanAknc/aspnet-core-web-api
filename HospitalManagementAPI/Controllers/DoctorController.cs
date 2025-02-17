using HospitalManagementAPI.Models;
using HospitalManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctor()
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(string id)
        {
            var doctors = await _doctorService.GetDoctorByIdAsync(id);
            if (doctors == null)
                return NotFound("Doktor bulunamadı.");

            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
                return BadRequest("Geçersiz doktor bilgileri");

            await _doctorService.CreateDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(string id, [FromBody] Doctor doctor)
        {
            if (doctor == null)
                return BadRequest("Geçersiz doktor bilgileri.");

            await _doctorService.UpdateDoctorAsync(id, doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }

        /*
         Tüm doktorları getirir → GET /api/doctors
         ID’ye göre doktor getirir → GET /api/doctors/{id}
         Yeni doktor ekler → POST /api/doctors
         Mevcut doktoru günceller → PUT /api/doctors/{id}
         Doktoru siler → DELETE /api/doctors/{id}
         */
    }
}
