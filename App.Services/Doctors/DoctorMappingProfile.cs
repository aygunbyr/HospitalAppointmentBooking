using App.Models.Dtos.Doctors;
using App.Models.Models;
using AutoMapper;

namespace App.Services.Doctors
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, DoctorResponse>();
            CreateMap<Doctor, DoctorAppointmentResponse>()
                .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));
            CreateMap<Doctor, CreateDoctorResponse>();
            CreateMap<CreateDoctorRequest, Doctor>();
            CreateMap<UpdateDoctorRequest, Doctor>();
        }
    }
}
