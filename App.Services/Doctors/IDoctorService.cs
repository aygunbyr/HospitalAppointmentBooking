using App.Models.Dtos.Doctors;
using App.Models.Models;

namespace App.Services.Doctors
{
    public interface IDoctorService
    {
        Task<ServiceResult<DoctorResponse?>> GetByIdAsync(int id);
        Task<ServiceResult<List<DoctorResponse>>> GetAllAsync();
        Task<ServiceResult<CreateDoctorResponse?>> CreateAsync(CreateDoctorRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateDoctorRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<DoctorAppointmentResponse>>> GetAllWithAppointmentsAsync();
        Task<ServiceResult<DoctorAppointmentResponse?>> GetByIdWithAppointmentsAsync(int id);
    }
}
