namespace App.Models.Dtos.Appointments
{
    public class AppointmentResponse
    {
        public Guid Id { get; init; }
        public DateTime Date { get; init; }
        public string DoctorBranch { get; init; } = string.Empty;
        public string DoctorName { get; init; } = string.Empty;
        public string PatientName { get; init; } = string.Empty;
        public string PatientPhone { get; init; } = string.Empty;
        public string PatientCitizenId { get; init; } = string.Empty;

        public AppointmentResponse() { }

        public AppointmentResponse(Guid id, DateTime date, string doctorBranch, string doctorName, string patientName, string patientPhone, string patientCitizenId)
        {
            Id = id;
            Date = date;
            DoctorBranch = doctorBranch;
            DoctorName = doctorName;
            PatientName = patientName;
            PatientPhone = patientPhone;
            PatientCitizenId = patientCitizenId;
        }
    }
}
