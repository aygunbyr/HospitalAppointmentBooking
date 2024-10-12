namespace App.Models.Models
{
    public sealed class Appointment : Entity<Guid>
    {
        public DateTime Date { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; } = default!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;
    }
}
