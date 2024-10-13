using App.Models.Models;
using App.Repositories.Doctors;

namespace App.Services.Doctors.Commands
{
    public class UpdateDoctorCommand : ICommand
    {
        private readonly Doctor _doctor;
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorCommand(Doctor doctor, IDoctorRepository doctorRepository)
        {
            _doctor = doctor;
            _doctorRepository = doctorRepository;
        }

        public Task ExecuteAsync()
        {
            _doctorRepository.Update(_doctor);
            return Task.CompletedTask;
        }
    }
}
