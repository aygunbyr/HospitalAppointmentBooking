using App.Models.Dtos.Doctors;
using App.Models.Dtos.Patients;
using App.Models.Models;
using App.Repositories.Patients;
using App.Repositories.Shared;
using AutoMapper;
using System.Net;
using System.Numerics;

namespace App.Services.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CreatePatientResponse>> CreateAsync(CreatePatientRequest request)
        {
            Patient patient = _mapper.Map<Patient>(request);
            await _patientRepository.AddAsync(patient);
            await _unitOfWork.SaveChangesAsync();
            CreatePatientResponse response = _mapper.Map<CreatePatientResponse>(patient);
            return ServiceResult<CreatePatientResponse>.SuccessAsCreated(response, $"api/patients/{patient.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(Guid id)
        {
            Patient? patient = await _patientRepository.GetByIdAsync(id);
            if(patient is null)
            {
                return ServiceResult.Fail("Patient not found", HttpStatusCode.NotFound);
            }
            _patientRepository.Delete(patient!);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<PatientResponse>>> GetAllAsync()
        {
            List<Patient> patients = await _patientRepository.GetAllAsync();
            List<PatientResponse> response = _mapper.Map<List<PatientResponse>>(patients);
            return ServiceResult<List<PatientResponse>>.Success(response);
        }

        public async Task<ServiceResult<PatientResponse?>> GetByIdAsync(Guid id)
        {
            Patient? patient = await _patientRepository.GetByIdAsync(id);
            if (patient is null)
            {
                return ServiceResult<PatientResponse?>.Fail("Patient not found", HttpStatusCode.NotFound);
            }
            PatientResponse response = _mapper.Map<PatientResponse>(patient);
            return ServiceResult<PatientResponse>.Success(response)!;
        }

        public async Task<ServiceResult> UpdateAsync(Guid id, UpdatePatientRequest request)
        {
            Patient patient = _mapper.Map<Patient>(request);
            patient.Id = id;
            _patientRepository.Update(patient);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<PatientAppointmentResponse>>> GetAllWithAppointmentsAsync()
        {
            List<Patient> patients = await _patientRepository.GetAllWithAppointmentsAsync();
            List<PatientAppointmentResponse> response = _mapper.Map<List<PatientAppointmentResponse>>(patients);
            return ServiceResult<List<PatientAppointmentResponse>>.Success(response);
        }

        public async Task<ServiceResult<PatientAppointmentResponse?>> GetByIdWithAppointmentsAsync(Guid id)
        {
            Patient? patient = await _patientRepository.GetByIdWithAppointmentsAsync(id);
            if (patient is null)
            {
                return ServiceResult<PatientAppointmentResponse?>.Fail("Patient not found", HttpStatusCode.NotFound);
            }
            PatientAppointmentResponse response = _mapper.Map<PatientAppointmentResponse>(patient);
            return ServiceResult<PatientAppointmentResponse>.Success(response)!;
        }
    }
}
