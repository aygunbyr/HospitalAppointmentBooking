namespace App.Models.Models
{
    public sealed class Doctor : Entity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public List<Appointment>? Appointments { get; set; }
    }
}
