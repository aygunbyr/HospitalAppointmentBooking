using App.Models.Dtos.Appointments;
using App.Models.Models;
using App.Repositories.Appointments;
using App.Repositories.Doctors;
using App.Repositories.Patients;
using App.Repositories.Shared;
using App.Services.Appointments.Commands;
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
        private readonly AppointmentCommandInvoker _invoker;
        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            AppointmentCommandInvoker invoker)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _invoker = invoker;
        }

        public async Task<ServiceResult<CreateAppointmentResponse?>> CreateAsync(CreateAppointmentRequest request)
        {
            if (request.DoctorId == 0)
            {
                return ServiceResult<CreateAppointmentResponse?>.Fail("Doctor does not exist", HttpStatusCode.BadRequest);
            }
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
                return ServiceResult<CreateAppointmentResponse?>.Fail("Doctor cannot have more than 10 appointments.", HttpStatusCode.BadRequest);
            }
            Appointment appointment = _mapper.Map<Appointment>(request);
            _invoker.AddCommand(new CreateAppointmentCommand(appointment, _appointmentRepository));
            await _invoker.ExecuteCommandsAsync();
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
            _invoker.AddCommand(new DeleteAppointmentCommand(appointment, _appointmentRepository));
            await _invoker.ExecuteCommandsAsync();
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
            if (request.DoctorId == 0)
            {
                return ServiceResult.Fail("Doctor does not exist", HttpStatusCode.BadRequest);
            }
            bool doctorExists = await _doctorRepository.AnyAsync(request.DoctorId);
            if (doctorExists is false)
            {
                return ServiceResult.Fail("Doctor does not exist", HttpStatusCode.BadRequest);
            }
            bool patientExists = await _patientRepository.AnyAsync(request.PatientId);
            if (patientExists is false)
            {
                return ServiceResult.Fail("Patient does not exist", HttpStatusCode.BadRequest);
            }
            Appointment appointment = _mapper.Map<Appointment>(request);
            appointment.Id = id;
            _invoker.AddCommand(new UpdateAppointmentCommand(appointment, _appointmentRepository));
            await _invoker.ExecuteCommandsAsync();
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
