namespace App.Models.Dtos.Appointments
{
    public record CreateAppointmentResponse(Guid Id, DateTime Date, Guid PatientId, int DoctorId);
}
