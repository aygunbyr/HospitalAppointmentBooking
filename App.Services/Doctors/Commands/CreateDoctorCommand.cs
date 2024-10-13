using App.Models.Models;
using App.Repositories.Doctors;

namespace App.Services.Doctors.Commands
{
    public class CreateDoctorCommand : ICommand
    {
        private readonly Doctor _doctor;
        private readonly IDoctorRepository _doctorRepository;

        public CreateDoctorCommand(Doctor doctor, IDoctorRepository doctorRepository)
        {
            _doctor = doctor;
            _doctorRepository = doctorRepository;
        }

        public async Task ExecuteAsync()
        {
            await _doctorRepository.AddAsync(_doctor);
        }
    }
}
