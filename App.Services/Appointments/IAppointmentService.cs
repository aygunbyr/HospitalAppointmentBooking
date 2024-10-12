using App.Models.Dtos.Appointments;
using App.Models.Models;
using System.Net;

namespace App.Services.Appointments
{
    public interface IAppointmentService
    {
        Task<ServiceResult<AppointmentResponse?>> GetByIdAsync(Guid id);
        Task<ServiceResult<List<AppointmentResponse>>> GetAllAsync();
        Task<ServiceResult<CreateAppointmentResponse?>> CreateAsync(CreateAppointmentRequest request);
        Task<ServiceResult> UpdateAsync(Guid id, UpdateAppointmentRequest request);
        Task<ServiceResult> DeleteAsync(Guid id);
        Task<ServiceResult<AppointmentResponse?>> GetByIdWithDetailsAsync(Guid id);
        Task<ServiceResult<List<AppointmentResponse>>> GetAllWithDetailsAsync();
    }
}
