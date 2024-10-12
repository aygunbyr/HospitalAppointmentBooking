namespace App.Models.Dtos.Patients
{
    public record CreatePatientResponse(Guid Id, string FullName, string Phone, string CitizenId);
}
