using App.Models.Dtos.Appointments;
using App.Repositories.Appointments;
using FluentValidation;

namespace App.Services.Appointments
{
    public class UpdateAppointmentRequestValidator : AbstractValidator<UpdateAppointmentRequest>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public UpdateAppointmentRequestValidator(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;

            RuleFor(x => x.Date)
                .Must(date => date.Date >= DateTime.Today && date.Date <= DateTime.Today.AddDays(3))
                .WithMessage("The appointment date must be within 3 days from today.");
        }
    }
}
