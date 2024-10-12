using App.Models.Dtos.Appointments;

namespace App.Models.Dtos.Doctors
{
    public record DoctorAppointmentResponse(
        int Id,
        string Name,
        string Branch,
        List<AppointmentResponse> Appointments);
}
