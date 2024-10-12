using App.Models.Dtos.Appointments;
using App.Models.Models;
using App.Repositories.Appointments;
using App.Repositories.Doctors;
using App.Repositories.Patients;
using App.Repositories.Shared;
using AutoMapper;
using System.Net;

namespace App.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CreateAppointmentResponse?>> CreateAsync(CreateAppointmentRequest request)
        {
            bool doctorExists = await _doctorRepository.AnyAsync(request.DoctorId);
            if(doctorExists is false)
            {
                return ServiceResult<CreateAppointmentResponse?>.Fail("Doctor does not exist", HttpStatusCode.BadRequest);
            }
            bool patientExists = await _patientRepository.AnyAsync(request.PatientId);
            if(patientExists is false)
            {
                return ServiceResult<CreateAppointmentResponse?>.Fail("Patient does not exist", HttpStatusCode.BadRequest);
            }
            List<Appointment> appointments = await _appointmentRepository.Where(x => x.DoctorId == request.DoctorId);
            if(appointments.Count >= 10)
            {
                return ServiceResult<CreateAppointmentResponse?>.Fail("Doctor cannot have more than 10 appointments.");
            }
            Appointment appointment = _mapper.Map<Appointment>(request);
            await _appointmentRepository.AddAsync(appointment);
            await _unitOfWork.SaveChangesAsync();
            CreateAppointmentResponse response = _mapper.Map<CreateAppointmentResponse>(appointment);
            return ServiceResult<CreateAppointmentResponse>.SuccessAsCreated(response, $"api/appointments/{appointment.Id}")!;
        }

        public async Task<ServiceResult> DeleteAsync(Guid id)
        {
            Appointment? appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment is null)
            {
                return ServiceResult.Fail("Appointment not found", HttpStatusCode.NotFound);
            }
            _appointmentRepository.Delete(appointment!);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<AppointmentResponse>>> GetAllAsync()
        {
            List<Appointment> appointments = await _appointmentRepository.GetAllAsync();
            List<AppointmentResponse> response = _mapper.Map<List<AppointmentResponse>>(appointments);
            return ServiceResult<List<AppointmentResponse>>.Success(response);
        }

        public async Task<ServiceResult<AppointmentResponse?>> GetByIdAsync(Guid id)
        {
            Appointment? appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment is null)
            {
                return ServiceResult<AppointmentResponse?>.Fail("Appointment not found", HttpStatusCode.NotFound);
            }
            AppointmentResponse response = _mapper.Map<AppointmentResponse>(appointment);
            return ServiceResult<AppointmentResponse>.Success(response)!;
        }

        public async Task<ServiceResult> UpdateAsync(Guid id, UpdateAppointmentRequest request)
        {
            Appointment appointment = _mapper.Map<Appointment>(request);
            appointment.Id = id;
            _appointmentRepository.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<AppointmentResponse?>> GetByIdWithDetailsAsync(Guid id)
        {
            Appointment? appointment = await _appointmentRepository.GetByIdWithDetailsAsync(id);
            if (appointment is null)
            {
                return ServiceResult<AppointmentResponse?>.Fail("Appointment not found", HttpStatusCode.NotFound);
            }
            AppointmentResponse response = _mapper.Map<AppointmentResponse>(appointment);
            return ServiceResult<AppointmentResponse>.Success(response)!;
        }

        public async Task<ServiceResult<List<AppointmentResponse>>> GetAllWithDetailsAsync()
        {
            List<Appointment> appointments = await _appointmentRepository.GetAllWithDetailsAsync();
            List<AppointmentResponse> response = _mapper.Map<List<AppointmentResponse>>(appointments);
            return ServiceResult<List<AppointmentResponse>>.Success(response);
        }
    }
}
