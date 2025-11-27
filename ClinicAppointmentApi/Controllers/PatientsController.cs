using ClinicAppointmentApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private static List<Patient> _patients = new()
    {
        new() { Id = 1, FirstName = "שרה", LastName = "לוי", Phone = "050-1234567" },
        new() { Id = 2, FirstName = "דוד", LastName = "כהן", Phone = "052-9876543" }
    };
        private static int _nextId = 3;

        [HttpGet] public ActionResult<List<Patient>> Get() => Ok(_patients.Where(p => p.IsActive));

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id && p.IsActive);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public ActionResult<Patient> Post(Patient patient)
        {
            patient.Id = _nextId++;
            patient.IsActive = true;
            _patients.Add(patient);
            return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Patient patient)
        {
            var existing = _patients.FirstOrDefault(p => p.Id == id && p.IsActive);
            if (existing == null) return NotFound();
            existing.FirstName = patient.FirstName;
            existing.LastName = patient.LastName;
            existing.Phone = patient.Phone;
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public ActionResult Deactivate(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null) return NotFound();
            patient.IsActive = false;
            return NoContent();
        }
    }
}
