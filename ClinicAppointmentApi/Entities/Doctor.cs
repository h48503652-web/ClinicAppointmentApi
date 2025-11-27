namespace ClinicAppointmentApi.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
