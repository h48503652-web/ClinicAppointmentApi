using ClinicAppointmentApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private static List<Doctor> _doctors = new()
    {
        new() { Id = 1, FirstName = "ד״ר יעל", LastName = "אבוטבול", Specialty = "רופאת ילדים" },
        new() { Id = 2, FirstName = "ד״ר משה", LastName = "פרידמן", Specialty = "רופא משפחה" }
    };
        private static int _nextId = 3;

        [HttpGet] public ActionResult<List<Doctor>> Get() => Ok(_doctors.Where(d => d.IsActive));

        [HttpGet("{id}")]
        public ActionResult<Doctor> Get(int id)
        {
            var doctor = _doctors.FirstOrDefault(d => d.Id == id && d.IsActive);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public ActionResult<Doctor> Post(Doctor doctor)
        {
            doctor.Id = _nextId++;
            doctor.IsActive = true;
            _doctors.Add(doctor);
            return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Doctor doctor)
        {
            var existing = _doctors.FirstOrDefault(d => d.Id == id && d.IsActive);
            if (existing == null) return NotFound();
            existing.FirstName = doctor.FirstName;
            existing.LastName = doctor.LastName;
            existing.Specialty = doctor.Specialty;
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public ActionResult Deactivate(int id)
        {
            var doctor = _doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null) return NotFound();
            doctor.IsActive = false;
            return NoContent();
        }
    }
}
