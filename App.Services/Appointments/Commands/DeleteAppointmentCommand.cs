using App.Models.Models;
using App.Repositories.Appointments;

namespace App.Services.Appointments.Commands
{
    public class DeleteAppointmentCommand : ICommand
    {
        private readonly Appointment _appointment;
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteAppointmentCommand(Appointment appointment, IAppointmentRepository appointmentRepository)
        {
            _appointment = appointment;
            _appointmentRepository = appointmentRepository;
        }

        public Task ExecuteAsync()
        {
            _appointmentRepository.Delete(_appointment);
            return Task.CompletedTask;
        }
    }
}
