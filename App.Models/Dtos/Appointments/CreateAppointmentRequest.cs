namespace App.Models.Dtos.Appointments
{
    public record CreateAppointmentRequest(DateTime Date, Guid PatientId, int DoctorId);
}
