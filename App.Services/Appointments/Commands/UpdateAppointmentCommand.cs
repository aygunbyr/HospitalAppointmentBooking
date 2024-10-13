using App.Models.Models;
using App.Repositories.Appointments;

namespace App.Services.Appointments.Commands
{
    public class UpdateAppointmentCommand : ICommand
    {
        private readonly Appointment _appointment;
        private readonly IAppointmentRepository _appointmentRepository;

        public UpdateAppointmentCommand(Appointment appointment, IAppointmentRepository appointmentRepository)
        {
            _appointment = appointment;
            _appointmentRepository = appointmentRepository;
        }

        public Task ExecuteAsync()
        {
            _appointmentRepository.Update(_appointment);
            return Task.CompletedTask;
        }
    }
}
