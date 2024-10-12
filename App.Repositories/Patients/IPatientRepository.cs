using App.Models.Models;
using App.Repositories.Shared;

namespace App.Repositories.Patients
{
    public interface IPatientRepository : IGenericRepository<Patient, Guid>
    {
        Task<Patient?> GetByIdWithAppointmentsAsync(Guid id);
        Task<List<Patient>> GetAllWithAppointmentsAsync();
    }
}
