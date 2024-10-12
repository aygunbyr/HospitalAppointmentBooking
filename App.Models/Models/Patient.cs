namespace App.Models.Models
{
    public sealed class Patient : Entity<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CitizenId { get; set; } = string.Empty;
        public List<Appointment>? Appointments { get; set; }
    }
}
