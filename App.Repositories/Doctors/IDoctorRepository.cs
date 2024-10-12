using App.Models.Models;
using App.Repositories.Shared;

namespace App.Repositories.Doctors
{
    public interface IDoctorRepository : IGenericRepository<Doctor, int>
    {
        Task<Doctor?> GetByIdWithAppointmentsAsync(int id);
        Task<List<Doctor>> GetAllWithAppointmentsAsync();
    }
}
