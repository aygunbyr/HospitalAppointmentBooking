using App.Models.Dtos.Appointments;

namespace App.Models.Dtos.Patients
{
    public record PatientAppointmentResponse(
        Guid Id,
        string FullName,
        string Phone,
        string CitizenId,
        List<AppointmentResponse> Appointments);
}
