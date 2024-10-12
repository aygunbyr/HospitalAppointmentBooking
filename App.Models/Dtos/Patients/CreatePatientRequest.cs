namespace App.Models.Dtos.Patients
{
    public record CreatePatientRequest(string FullName, string Phone, string CitizenId);
}
