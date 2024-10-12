namespace App.Models.Dtos.Appointments
{
    public record UpdateAppointmentRequest(DateTime Date, Guid PatientId, int DoctorId);
}
