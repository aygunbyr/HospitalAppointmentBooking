using App.Models.Dtos.Appointments;
using App.Repositories.Appointments;
using FluentValidation;

namespace App.Services.Appointments
{
    public class CreateAppointmentRequestValidator : AbstractValidator<CreateAppointmentRequest>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentRequestValidator(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;

            RuleFor(x => x.Date)
                .Must(date => date.Date >= DateTime.Today.AddDays(3))
                .WithMessage("The appointment date must be at least 3 days later than today.");
        }
    }
}
