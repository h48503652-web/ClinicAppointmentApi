namespace ClinicAppointmentApi.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Notes { get; set; }
        public bool IsCancelled { get; set; } = false;
    }
}
