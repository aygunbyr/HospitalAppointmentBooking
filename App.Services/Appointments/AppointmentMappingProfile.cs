using App.Models.Dtos.Appointments;
using App.Models.Models;
using AutoMapper;

namespace App.Services.Appointments
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<Appointment, AppointmentResponse>()
                .ForMember(dest => dest.DoctorBranch, opt => opt.MapFrom(src => src.Doctor.Branch))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.PatientPhone, opt => opt.MapFrom(src => src.Patient.Phone))
                .ForMember(dest => dest.PatientCitizenId, opt => opt.MapFrom(src => src.Patient.CitizenId));
            CreateMap<Appointment, CreateAppointmentResponse>();
            CreateMap<CreateAppointmentRequest, Appointment>();
            CreateMap<UpdateAppointmentRequest, Appointment>();
        }
    }
}
