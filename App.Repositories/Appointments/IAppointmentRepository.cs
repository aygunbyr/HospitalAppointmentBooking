using App.Models.Models;
using App.Repositories.Shared;

namespace App.Repositories.Appointments
{
    public interface IAppointmentRepository : IGenericRepository<Appointment, Guid>
    {
        Task<Appointment?> GetByIdWithDetailsAsync(Guid id);
        Task<List<Appointment>> GetAllWithDetailsAsync();
    }
}
