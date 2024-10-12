using App.Models.Dtos.Patients;
using App.Models.Models;
using AutoMapper;

namespace App.Services.Patients
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, PatientResponse>();
            CreateMap<Patient, PatientAppointmentResponse>()
                .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));
            CreateMap<Patient, CreatePatientResponse>();
            CreateMap<CreatePatientRequest, Patient>();
            CreateMap<UpdatePatientRequest, Patient>();
        }
    }
}
