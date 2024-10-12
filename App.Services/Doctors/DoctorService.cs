using App.Models.Dtos.Doctors;
using App.Models.Models;
using App.Repositories.Doctors;
using App.Repositories.Shared;
using AutoMapper;
using System.Net;

namespace App.Services.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CreateDoctorResponse?>> CreateAsync(CreateDoctorRequest request)
        {
            string[] branches = Branch.GetAllBranches();
            if (branches.Any(x => x == request.Branch) is false)
            {
                return ServiceResult<CreateDoctorResponse?>.Fail($"Branch name is invalid. Must be one of {string.Join(", ", branches)}.", HttpStatusCode.NotFound);
            }
            Doctor doctor = _mapper.Map<Doctor>(request);
            await _doctorRepository.AddAsync(doctor);
            await _unitOfWork.SaveChangesAsync();
            CreateDoctorResponse response = _mapper.Map<CreateDoctorResponse>(doctor);
            return ServiceResult<CreateDoctorResponse>.SuccessAsCreated(response, $"api/doctors/{doctor.Id}")!;
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            Doctor? doctor = await _doctorRepository.GetByIdAsync(id);
            if(doctor is null)
            {
                return ServiceResult.Fail("Doctor not found", HttpStatusCode.NotFound);
            }
            _doctorRepository.Delete(doctor!);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<DoctorResponse>>> GetAllAsync()
        {
            List<Doctor> doctors = await _doctorRepository.GetAllAsync();
            List<DoctorResponse> response = _mapper.Map<List<DoctorResponse>>(doctors);
            return ServiceResult<List<DoctorResponse>>.Success(response);
        }

        public async Task<ServiceResult<DoctorResponse?>> GetByIdAsync(int id)
        {
            Doctor? doctor = await _doctorRepository.GetByIdAsync(id);
            if(doctor is null)
            {
                return ServiceResult<DoctorResponse?>.Fail("Doctor not found", HttpStatusCode.NotFound);
            }
            DoctorResponse response = _mapper.Map<DoctorResponse>(doctor);
            return ServiceResult<DoctorResponse>.Success(response)!;
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateDoctorRequest request)
        {
            string[] branches = Branch.GetAllBranches();
            if (branches.Any(x => x == request.Branch) is false)
            {
                return ServiceResult.Fail($"Branch name is invalid. Must be one of {string.Join(", ", branches)}.", HttpStatusCode.NotFound);
            }
            Doctor doctor = _mapper.Map<Doctor>(request);
            doctor.Id = id;
            _doctorRepository.Update(doctor);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<DoctorAppointmentResponse>>> GetAllWithAppointmentsAsync()
        {
            List<Doctor> doctors = await _doctorRepository.GetAllWithAppointmentsAsync();
            List<DoctorAppointmentResponse> response = _mapper.Map<List<DoctorAppointmentResponse>>(doctors);
            return ServiceResult<List<DoctorAppointmentResponse>>.Success(response);
        }

        public async Task<ServiceResult<DoctorAppointmentResponse?>> GetByIdWithAppointmentsAsync(int id)
        {
            Doctor? doctor = await _doctorRepository.GetByIdWithAppointmentsAsync(id);
            if (doctor is null)
            {
                return ServiceResult<DoctorAppointmentResponse?>.Fail("Doctor not found", HttpStatusCode.NotFound);
            }
            DoctorAppointmentResponse response = _mapper.Map<DoctorAppointmentResponse>(doctor);
            return ServiceResult<DoctorAppointmentResponse>.Success(response)!;
        }
    }
}
