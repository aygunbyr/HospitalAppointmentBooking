using App.Models.Models;
using App.Repositories.Appointments;

namespace App.Services.Appointments.Commands
{
    public class CreateAppointmentCommand : ICommand
    {
        private readonly Appointment _appointment;
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentCommand(Appointment appointment, IAppointmentRepository appointmentRepository)
        {
            _appointment = appointment;
            _appointmentRepository = appointmentRepository;
        }

        public async Task ExecuteAsync()
        {
            await _appointmentRepository.AddAsync(_appointment);
        }
    }
}
