namespace App.Models.Dtos.Patients
{
    public record PatientResponse(Guid Id, string FullName, string Phone, string CitizenId);
}
