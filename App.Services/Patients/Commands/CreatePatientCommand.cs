using App.Models.Models;
using App.Repositories.Patients;

namespace App.Services.Patients.Commands
{
    public class CreatePatientCommand : ICommand
    {
        private readonly Patient _patient;
        private readonly IPatientRepository _patientRepository;

        public CreatePatientCommand(Patient patient, IPatientRepository patientRepository)
        {
            _patient = patient;
            _patientRepository = patientRepository;
        }

        public async Task ExecuteAsync()
        {
            await _patientRepository.AddAsync(_patient);
        }
    }
}
