using ClinicAppointmentApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private static List<Appointment> _appointments = new()
    {
        new() { Id = 1, PatientId = 1, DoctorId = 1, DateTime = new DateTime(2025, 12, 10, 10, 0, 0) }
    };
        private static int _nextId = 2;

        [HttpGet] public ActionResult<List<Appointment>> Get() => Ok(_appointments.Where(a => !a.IsCancelled));

        [HttpGet("{id}")]
        public ActionResult<Appointment> Get(int id)
        {
            var app = _appointments.FirstOrDefault(a => a.Id == id);
            if (app == null || app.IsCancelled) return NotFound();
            return Ok(app);
        }

        [HttpPost]
        public ActionResult<Appointment> Post(Appointment appointment)
        {
            appointment.Id = _nextId++;
            appointment.IsCancelled = false;
            _appointments.Add(appointment);
            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Appointment appointment)
        {
            var existing = _appointments.FirstOrDefault(a => a.Id == id);
            if (existing == null || existing.IsCancelled) return NotFound();
            existing.PatientId = appointment.PatientId;
            existing.DoctorId = appointment.DoctorId;
            existing.DateTime = appointment.DateTime;
            existing.Notes = appointment.Notes;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var app = _appointments.FirstOrDefault(a => a.Id == id);
            if (app == null) return NotFound();
            _appointments.Remove(app);
            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        public ActionResult Cancel(int id)
        {
            var app = _appointments.FirstOrDefault(a => a.Id == id);
            if (app == null) return NotFound();
            app.IsCancelled = true;
            return NoContent();
        }
    }
}
