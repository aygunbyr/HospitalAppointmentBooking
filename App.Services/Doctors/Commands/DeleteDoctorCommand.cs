using App.Models.Models;
using App.Repositories.Doctors;

namespace App.Services.Doctors.Commands
{
    public class DeleteDoctorCommand : ICommand
    {
        private readonly Doctor _doctor;
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorCommand(Doctor doctor, IDoctorRepository doctorRepository)
        {
            _doctor = doctor;
            _doctorRepository = doctorRepository;
        }

        public Task ExecuteAsync()
        {
            _doctorRepository.Delete(_doctor);
            return Task.CompletedTask;
        }
    }
}
