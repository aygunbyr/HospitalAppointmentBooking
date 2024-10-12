using App.Models.Dtos.Patients;
using App.Models.Models;

namespace App.Services.Patients
{
    public interface IPatientService
    {
        Task<ServiceResult<PatientResponse?>> GetByIdAsync(Guid id);
        Task<ServiceResult<List<PatientResponse>>> GetAllAsync();
        Task<ServiceResult<CreatePatientResponse>> CreateAsync(CreatePatientRequest request);
        Task<ServiceResult> UpdateAsync(Guid id, UpdatePatientRequest request);
        Task<ServiceResult> DeleteAsync(Guid id);
        Task<ServiceResult<List<PatientAppointmentResponse>>> GetAllWithAppointmentsAsync();
        Task<ServiceResult<PatientAppointmentResponse?>> GetByIdWithAppointmentsAsync(Guid id);
    }
}
